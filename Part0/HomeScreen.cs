using System;
using MonoTouch.UIKit;

namespace Part0
{
    public class HomeScreen : UIViewController 
    {
        UITableView table;

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            table = new UITableView(View.Bounds); // defaults to Plain style
            table.AutoresizingMask = UIViewAutoresizing.All;
            string[] tableItems = new string[] {"Vegetables","Fruits","Flower Buds","Legumes","Bulbs","Tubers"};
            table.Source = new TableSource(tableItems);
            Add (table);
        }
    }}

