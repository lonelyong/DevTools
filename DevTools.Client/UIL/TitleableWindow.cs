using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DevTools.Client.UIL
{
	public class TitleableWindow : Window
	{
		private Image _iconImage;

		private Label _titleLable;

		private DockPanel _titleButtonGroupDockPanel;

		private Label _minsizeLabel;

		private Label _maxsizeLabel;

		private Label _closeLabel;

		private Grid _titleGrid;

		protected Grid RootGrid { get; }

		public TitleableWindow()
		{
			RootGrid = new Grid() {

			};
			RootGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(30, GridUnitType.Pixel)});
			RootGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
			
			_iconImage = new Image() {
				
			};
			_iconImage.SetValue(Grid.ColumnProperty, 0);
			_titleLable = new Label() {
				Content = "DevTools",
			};
			_titleLable.SetValue(Grid.ColumnProperty, 1);
			_minsizeLabel = new Label() { Content = "-", Width = 30 };
			_maxsizeLabel = new Label() { Content = "=", Width = 30 };
			_closeLabel = new Label() { Content = "x", Width = 30 };

			_titleButtonGroupDockPanel = new DockPanel() {
			
			};
			_titleButtonGroupDockPanel.Children.Add(_minsizeLabel);
			_titleButtonGroupDockPanel.Children.Add(_maxsizeLabel);
			_titleButtonGroupDockPanel.Children.Add(_closeLabel);
			_titleButtonGroupDockPanel.SetValue(Grid.ColumnProperty, 2);
			_titleGrid = new Grid() {
				Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green)
			};
			_titleGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(30, GridUnitType.Pixel) });
			_titleGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
			_titleGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(90, GridUnitType.Pixel) });
			_titleGrid.Children.Add(_iconImage);
			_titleGrid.Children.Add(_titleLable);
			_titleGrid.Children.Add(_titleButtonGroupDockPanel);
			_titleGrid.SetValue(Grid.RowProperty, 0);

			//_titleButtonGroupDockPanel.SetValue();
			RootGrid.Children.Add(_titleGrid);
			
			this.AddChild(RootGrid);
		}
	}
}
