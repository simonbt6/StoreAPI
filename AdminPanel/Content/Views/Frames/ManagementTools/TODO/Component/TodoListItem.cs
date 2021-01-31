using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using MaterialDesignThemes.Wpf;
using AdminPanel.Data.Database.Query;

namespace AdminPanel.Content.Views.Frames.ManagementTools.TODO.Component
{
    public class TodoListItem : ListViewItem
    {
        private Brush blue;
        private readonly Management.TODO todo;
        private readonly TodoPage todoPage;

        public TodoListItem(Management.TODO todo, TodoPage page)
        {
            this.todo = todo;
            this.todoPage = page;

            BrushConverter bc = new BrushConverter();
            blue = (Brush)bc.ConvertFrom("#FF2196F3");
            blue.Freeze();
            
            // ListItem property
            Background = Brushes.White;
            Effect = new DropShadowEffect
            {
                Opacity = 0.1
            };
            
            // Button
            Button button = new Button
            {
                Padding = new Thickness(9),
                Background = blue,
                BorderBrush = blue,
                Foreground = Brushes.White
            };

            // Button checkmark icon.
            PackIcon checkIcon = new PackIcon();
            checkIcon.Kind = PackIconKind.Check;
            button.Content = checkIcon;

            // Button click event
            button.Click += clickCheckmark;

            // Textblock
            TextBlock todoTitleBox = new TextBlock
            {
                Text = todo.GetTitle(),
                Margin = new Thickness(30, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center
            };

            // Grid
            ColumnDefinition c1 = new ColumnDefinition
            {
                Width = new GridLength(1, GridUnitType.Star)
            };
            ColumnDefinition c2 = new ColumnDefinition
            {
                Width = new GridLength(1, GridUnitType.Star)
            };
            Grid gridContainer = new Grid();
            gridContainer.ColumnDefinitions.Add(c1);
            gridContainer.ColumnDefinitions.Add(c2);
            gridContainer.Children.Add(todoTitleBox);
            gridContainer.Children.Add(button);
            Grid.SetColumn(button, 0);
            Grid.SetColumn(todoTitleBox, 1);
            
            AddChild(gridContainer);
        }

        private void clickCheckmark(object sender, RoutedEventArgs args)
        {
            // Remove todo
            TODOQuery.endTODO(todo);
            todoPage.todoList.Items.Remove(this);
        }
        
        public Management.TODO getTODO()
        {
            return todo;
        }
    }
}
