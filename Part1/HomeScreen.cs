using System;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace Part1
{
    public class HomeScreen : UIViewController 
    {
        UITableView table;

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            table = new UITableView(View.Bounds); // defaults to Plain style
            table.AutoresizingMask = UIViewAutoresizing.All;
            var tableSource = new TableSource<string>(new List<string>{"Vegetables","Fruits","Flower Buds","Legumes","Bulbs","Tubers"});
            tableSource.OnRowSelected += (object sender, TableSource<string>.RowSelectedEventArgs e) => {
                new UIAlertView("Row Selected", 
                                tableSource.Data[e.indexPath.Row].ToString(), null, "OK", null).Show();
                e.tableView.DeselectRow (e.indexPath, true);
            };
            table.Source = tableSource;
            Add (table);
        }
    }
}
