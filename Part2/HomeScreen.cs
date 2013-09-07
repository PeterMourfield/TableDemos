using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using RestSharp;

namespace Part2
{
    public class HomeScreen : UIViewController 
    {
        UITableView table;

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            table = new UITableView(View.Bounds); // defaults to Plain style
            table.AutoresizingMask = UIViewAutoresizing.All;
            var tableSource = new TableSource<Question>();
            tableSource.OnRowSelected += (object sender, TableSource<Question>.RowSelectedEventArgs e) => {
                new UIAlertView("Row Selected", 
                                tableSource.Data[e.indexPath.Row].ToString(), null, "OK", null).Show();
                e.tableView.DeselectRow (e.indexPath, true);
            };
            table.Source = tableSource;
            Add (table);

            LoadData();
        }

        void LoadData()
        {
            var request = new RestRequest {RootElement = "items", Resource = "/questions/featured"};
            request.AddParameter("site", "stackoverflow");

            var client = new RestClient("http://api.stackexchange.com/2.1");
            client.ExecuteAsync<List<Question>> (request, response => {
                // do work on UI thread
                InvokeOnMainThread(delegate {
                    // pass the data to the TableSource class
                    ((TableSource<Question>)table.Source).Data = response.Data;

                    // make the TableView reload the data
                    table.ReloadData();
                });
            });
        }
    }
}
