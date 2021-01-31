using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using AdminPanel.Data.Database.Query;
using AdminPanel.Content.Model.User;

namespace AdminPanel.Content.Views.Frames.ManagementTools.TODO
{
    /// <summary>
    /// Interaction logic for TodoPage.xaml
    /// </summary>
    public partial class TodoPage : Page
    {
        private List<Management.TODO> todos;
        private User user;

        public TodoPage(AdminUser user)
        {
            this.user = user;
            InitializeComponent();
            todos = TODOQuery.getAll();

            if(todos.Count > 0)
            {
                todos.ForEach(todo =>
                {
                    Component.TodoListItem t = new Component.TodoListItem(todo, this);
                    todoList.Items.Add(t);
                });
            }
            else
            {
                Console.WriteLine("No todo");
            }


            todoList.SelectionChanged += selectedTODO;
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if((sender as ToggleButton).IsChecked ?? false)
            {
                cTODOEndDatePicker.IsEnabled = true;
            }
            else
            {
                cTODOEndDatePicker.IsEnabled = false;
            }
        }

        private void addTODO(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("add TODO button");
            if(cTODOTitle.Text !=""
                && cTODODescription.Text !=""
                && cTODOPriority.Text !=""
                && cTODOEndDatePicker.SelectedDate.Value.Date !=null)
            {
                int priority = 0;
                switch (cTODOPriority.Text)
                {
                    case "Normal":
                        priority = 0;
                        break;
                    case "Soon":
                        priority = 1;
                        break;
                    case "Urgent":
                        priority = 2;
                        break;
                    default:
                        priority = 0;
                        break;
                }
                Console.WriteLine(priority + cTODOPriority.Text);
                DateTime EndingAt = cTODOEndDatePicker.SelectedDate.Value.Date;
                Management.TODO todo = new Management.TODO(cTODOTitle.Text, // TODO Title
                    cTODODescription.Text, // TODO Description
                    user.getID(), // User id
                    priority, // Priority
                    DateTime.Now.Date, // UpdatedAt
                    DateTime.Now.Date, // CreatedAt
                    DateTime.Now.Date, // StartingAt
                    EndingAt // EndingAt
                );
                TODOQuery.addTODO(todo);
                todoList.Items.Add(new Component.TodoListItem(todo, this));



            }
        }

        private void selectedTODO(object sender, SelectionChangedEventArgs args)
        {
            Component.TodoListItem item = null;
            try
            {
                item = (Component.TodoListItem)(sender as ListView).SelectedItem;

                addNewTODOGrid.Visibility = Visibility.Hidden;

                todoPreviewTitle.Text = item.getTODO().GetTitle();
                todoPreviewDescription.Text = item.getTODO().GetDescription();
                Console.WriteLine(item.getTODO().GetTitle());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            
        }

        private void makeVisibleAddTODO(object sender, RoutedEventArgs e)
        {
            addNewTODOGrid.Visibility = Visibility.Visible;
        }
    }
}
