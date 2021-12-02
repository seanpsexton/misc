using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace WpfApp1
{
    public class MyDataGrid : DataGrid
    {
        private const string PART_DataGrid = "PART_DataGrid";
        private DataGrid dataGrid;
        private int instanceID;
        private static int NumInstances = 0;

        static MyDataGrid()
        {
            CommandManager.RegisterClassCommandBinding(typeof(UIElement), new CommandBinding(SelectColumnGroupCommand, OnExecutedSelectColumnGroup, OnCanExecuteSelectColumnGroup));
        }

        public MyDataGrid()
        {
            NumInstances++;
            instanceID = NumInstances;
        }

        public int InstanceID => instanceID;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild(PART_DataGrid) is DataGrid dg)
            {
                dataGrid = dg;
                dg.Loaded += Dg_Loaded;
            }
        }

        public static readonly RoutedCommand SelectColumnGroupCommand = new RoutedCommand("SelectColumnGroup", typeof(MyDataGrid));

        public static readonly DependencyProperty DefaultColumnGroupProperty = DependencyProperty.Register(
            nameof(DefaultColumnGroup), typeof(object), typeof(MyDataGrid),
            new PropertyMetadata(null, OnDefaultColumnGroupChanged));

        public object DefaultColumnGroup
        {
            get => GetValue(DefaultColumnGroupProperty); 
            set => SetValue(DefaultColumnGroupProperty, value); 
        }

        public static readonly DependencyProperty ColumnGroupDependencyProperty =
                  DependencyProperty.RegisterAttached("ColumnGroup", typeof(object), typeof(MyDataGrid),
                      new PropertyMetadata(null)); 

        public static object GetColumnGroup(DependencyObject depObj)
        {
            return depObj.GetValue(ColumnGroupDependencyProperty);
        }

        public static void SetColumnGroup(DependencyObject depObj, object value)
        {
            depObj.SetValue(ColumnGroupDependencyProperty, value);
        }

        private void Dg_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            dataGrid.Columns.Clear();

            foreach (var column in this.Columns)
            {
                var dataGridTextCol = column as DataGridBoundColumn;
                var binding = dataGridTextCol?.Binding as Binding;
                var bindingPath = binding?.Path?.Path ?? column.Header.ToString();

                dataGrid.Columns.Add(new DataGridTextColumn
                {
                    Header = column.Header,
                    Binding = new Binding(bindingPath)
                }); 
            }

            MakeColumnGroupVisible(DefaultColumnGroup?.ToString());
        }

        private static void OnCanExecuteSelectColumnGroup(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private static void OnExecutedSelectColumnGroup(object sender, ExecutedRoutedEventArgs e)
        {
            // Note: Client can use any type it likes for ColumnGroup attached property and command
            // parameter, e.g. a custom Enum. This class can't know type being used, but needs to
            // use value equality to determine if a column is associated with a particular group.
            var colGroupSelect = e.Parameter.ToString();

            if ((sender is MyDataGrid myDataGrid) && (!string.IsNullOrWhiteSpace(colGroupSelect)))
            {
                myDataGrid.MakeColumnGroupVisible(colGroupSelect);
            }
        }

        private static void OnDefaultColumnGroupChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if ((sender is MyDataGrid myDataGrid) && myDataGrid.IsLoaded)
            {
                myDataGrid.MakeColumnGroupVisible(e.NewValue?.ToString());
            }
        }

        private void MakeColumnGroupVisible(string columnGroupSelect)
        {
            foreach (var col in Columns)
            {
                // Attached prop is on MyDataGrid cols
                var colGroup = GetColumnGroup(col)?.ToString();

                if (!string.IsNullOrWhiteSpace(colGroup))
                {
                    var dgCol = dataGrid.Columns.Where(dgc => (string)dgc.Header == (string)col.Header).FirstOrDefault();

                    if (dgCol != null)
                    {
                        // Actual visibility is set on DataGrid cols
                        dgCol.Visibility = (colGroup == columnGroupSelect) ? Visibility.Visible : Visibility.Collapsed;
                    }
                }
            }
        }
    }
}
