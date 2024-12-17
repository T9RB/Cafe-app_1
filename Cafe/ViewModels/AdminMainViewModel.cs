using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using Cafe.Views;
using Cafe.Models.Models;
using ReactiveUI;
using IronXL;
//using Excel = Microsoft.Office.Interop.Excel;

namespace Cafe.ViewModels;

public class AdminMainViewModel : ViewModelBase
{
    private PageViewModelBase _CurrentPage;

    private ObservableCollection<Order> _orders;

    public PageViewModelBase CurrentPage
    {
        get { return _CurrentPage; }
        private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
    }

    public ObservableCollection<Order> Orders
    {
        get => _orders;
        set => this.RaiseAndSetIfChanged(ref _orders, value);
    }
    
    private readonly PageViewModelBase[] Pages = 
    { 
        new MenuPageViewModel(),
        new EmployeesPageViewModel(),
        new ProfilePageViewModel(),
        new OrdersPageViewModel()
    };
    
    public ICommand OpenMenuDishPage { get; }
    public ICommand OpenEmployeesPage { get; }
    public ICommand OpenProfilePage { get; }
    public ICommand OpenOrdersPage { get; }
    
    public ReactiveCommand<Window, Unit> ExitProfile { get; }
    public ReactiveCommand<Window, Unit> CreateReport { get; }

    public AdminMainViewModel()
    {
        _CurrentPage = Pages[0];
        ExitProfile = ReactiveCommand.Create<Window>(ExitProfileImpl);
        CreateReport = ReactiveCommand.Create<Window>(CreateReportImpl);

        Orders = new ObservableCollection<Order>(Helper.GetContext().Orders.ToList());
        
        var canOpenMenuDish = this.WhenAnyValue(x => x.CurrentPage.OpenMenuDishesPage);
        OpenMenuDishPage = ReactiveCommand.Create(OpenMenuDishPageImpl, canOpenMenuDish);
        
        var canOpenEmployeesPage = this.WhenAnyValue(x => x.CurrentPage.OpenEmployeesPage);
        OpenEmployeesPage = ReactiveCommand.Create(OpenEmployeespageImpl, canOpenEmployeesPage);
        
        var canOpenProfilePage = this.WhenAnyValue(x => x.CurrentPage.OpenProfilePage);
        OpenProfilePage = ReactiveCommand.Create(OpenProfilePageImpl, canOpenProfilePage);

        var canOpenOrdersPage = this.WhenAnyValue(x => x.CurrentPage.OpenOrdersPage);
        OpenOrdersPage = ReactiveCommand.Create(OpenOrdersPageImpl, canOpenOrdersPage);
    }

    private void CreateReportImpl(Window obj)
    {
        using(ExcelHelper helper = new ExcelHelper())
        {
            //if (helper.Open(filePath: Path.Combine(Environment.CurrentDirectory, @"C:\Users\Public\Documents\Отчёт о заказах.xlsx")))
            //{
               
                //application.Visible = true;
            //}
            
             int i = 0;
                var allOrders = Orders.ToList().OrderBy(p => p.DateAndTime).ToList();
                //var application = new Excel.Application();
                string[] month = new string[12] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", 
                                                            "Август", "Сентябрь", "Окрябрь", "Ноябрь", "Декабрь" };
                
                //application.SheetsInNewWorkbook = month.Length;
                
                WorkBook workbook = WorkBook.Create(ExcelFileFormat.XLSX);
                
                //Workbook workbook = Workbook.Add(Type.Missing);

                for (int j = 0; j < month.Length; ++j)
                {
                    int counter = 0;
                    int startRowIndex = 1;

                    //Excel.Worksheet worksheet = application.Worksheets.Item[j + 1];
                    WorkSheet worksheet = workbook.CreateWorkSheet(month[j]);
                    //worksheet.Name = month[j];

                    string column1 = "A" + Convert.ToString(startRowIndex);
                    string column2 = "B" + Convert.ToString(startRowIndex);
                    string column3 = "C" + Convert.ToString(startRowIndex);
                    
                    worksheet[column1].Value = "Номер";
                    worksheet[column2].Value = "Дата";
                    worksheet[column3].Value = "Цена";

                    startRowIndex++;

                    while (allOrders.Count > i)
                    {
                        if (allOrders[i].DateAndTime.Month == j + 1)
                        {
                            string column4 = "A" + Convert.ToString(startRowIndex);
                            string column5 = "B" + Convert.ToString(startRowIndex);
                            string column6 = "C" + Convert.ToString(startRowIndex);
                            worksheet[column4].Value = allOrders[i].IdOrder;
                            worksheet[column5].Value= allOrders[i].DateAndTime.ToString("yy-MM-dd");
                            worksheet[column6].Value = allOrders[i].Price;
                            counter++;
                        }
                        else
                        {
                            break;
                        }
                        i++;
                        startRowIndex++;
                    }
                    
                    //Excel.Range sumRange = worksheet.Range[worksheet["A" + Convert.ToString(startRowIndex)],}
                       // worksheet.Cells[2][startRowIndex]];
                    //sumRange.Merge();
                    //sumRange.Value = "Итого:";
                
                    string column7 = "C" + Convert.ToString(startRowIndex);
                    worksheet[column7].Formula = $"=SUM(C{startRowIndex - counter}:" + $"C{startRowIndex - 1}";

                   // worksheet.Columns.AutoFit();
                    //helper.Save();
                    workbook.SaveAs("/home/orders.xlsx");
                }
            
        }
    }

    private void ExitProfileImpl(Window obj)
    {
        AuthorizationViewModel.AuthUser = null;
        AuthorizationView av = new AuthorizationView();
        av.Show();
        obj.Close();
    }

    private void OpenOrdersPageImpl()
    {
        CurrentPage = Pages[3];
    }

    private void OpenProfilePageImpl()
    {
        CurrentPage = Pages[2];
    }

    private void OpenEmployeespageImpl()
    {
        CurrentPage = Pages[1];
    }

    private void OpenMenuDishPageImpl()
    {
        CurrentPage = Pages[0];
    }
}