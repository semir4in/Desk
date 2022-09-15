using MahApps.Metro.Controls;
using R4iny.Library.Gui.ImportedMethods;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

namespace R4iny.Library.Gui
{
    /// <summary>
    /// Base window from '<see cref="MetroWindow"/>'
    /// </summary>
    public class BaseWindow : MetroWindow
    {
        public BaseWindow()
        {
            this.TitleCharacterCasing = CharacterCasing.Normal;
            //this.SetResourceReference(Control.BackgroundProperty, "MahApps.Brushes.Window.Background");
            //this.SetResourceReference(Control.ForegroundProperty, "MahApps.Brushes.ThemeForeground");

            this.BorderThickness = new Thickness(1);
            this.WindowTitleBrush = Brushes.Transparent;

            this.IsDraggable = true;
            this.CloseMode = CloseModes.Exit;
        }

        /// <summary>
        /// If <see cref="BaseWindow"/> is draggable, <see cref="Window.DragMove"/> is enabled
        /// </summary>
        public bool IsDraggable
        {
            get => (bool)this.GetValue(BaseWindow.IsDraggableProperty);
            set => this.SetValue(BaseWindow.IsDraggableProperty, value);
        }
        public static readonly DependencyProperty IsDraggableProperty = DependencyProperty.Register(
            nameof(BaseWindow.IsDraggable),
            typeof(bool),
            typeof(BaseWindow));

        /// <summary>
        /// If <see cref="BaseWindow"/> is closing, it can be canceled by <see cref="CloseModes"/>
        /// </summary>
        public CloseModes CloseMode
        {
            get => (CloseModes)this.GetValue(BaseWindow.CloseModesProperty);
            set => this.SetValue(BaseWindow.CloseModesProperty, value);
        }
        public static readonly DependencyProperty CloseModesProperty = DependencyProperty.Register(
            nameof(BaseWindow.CloseMode),
            typeof(CloseModes),
            typeof(BaseWindow));

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (this.IsDraggable)
            {
                this.DragMove();
            }

            base.OnMouseLeftButtonDown(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            switch (this.CloseMode)
            {
                case CloseModes.Exit:
                    // do nothing
                    break;
                case CloseModes.Cancel:
                    e.Cancel = true;
                    break;
                case CloseModes.Hide:
                    e.Cancel = true;
                    this.Hide();
                    break;
                case CloseModes.Minimize:
                    e.Cancel = true;
                    this.WindowState = WindowState.Minimized;
                    break;
                case CloseModes.Ask:
                    throw new NotImplementedException();
            }

            base.OnClosing(e);
        }


        /// <summary>
        /// Show and activate '<see cref="BaseWindow"/>'
        /// </summary>
        public new bool Show()
        {
#if DEBUG
            base.Show();
#else            
            try
            {
                base.Show();
            }
            catch (InvalidOperationException ex)
            {
                System.Diagnostics.Debug.WriteLine($"{nameof(BaseWindow)}.{nameof(Show)} ERROR:: {ex.Message}");
                return false;
            }
#endif
            return this.Activate();
        }

        /// <summary>
        /// Set corner preference if possible for Windows 11
        /// </summary>
        public void SetCornerPreference(DwmWindowCornerPreference preference)
        {
            IntPtr hWnd = new WindowInteropHelper(Window.GetWindow(this)).EnsureHandle();
            var attribute = DwmWindowAttribute.WindowCornerPreference;

            DwmApi.DwmSetWindowAttribute(hWnd, attribute, ref preference, sizeof(uint));
        }
    }

    public enum CloseModes
    {
        Exit,
        Cancel,
        Hide,
        Minimize,
        Ask,
    }
}
