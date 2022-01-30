﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;
using VS = System.Windows.Forms.VisualStyles;

namespace QTech.Component
{
    /// <summary>
    /// Represents a pop-up window.
    /// </summary>
    [ToolboxItem(false)]
    public class Popup : ToolStripDropDown
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                if (content != null)
                {
                    System.Windows.Forms.Control _content = content;
                    content = null;
                    _content.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion

        #region " Fields & Properties "

        private Control content;
        /// <summary>
        /// Gets the content of the pop-up.
        /// </summary>
        public Control Content
        {
            get { return content; }
        }

        private PopupAnimations showingAnimation= PopupAnimations.None;
        /// <summary>
        /// Determines which animation to use while showing the pop-up window.
        /// </summary>
        public PopupAnimations ShowingAnimation
        {
            get { return showingAnimation; }
            set { if (showingAnimation != value) showingAnimation = value; }
        }

        private PopupAnimations hidingAnimation= PopupAnimations.None;
        /// <summary>
        /// Determines which animation to use while hiding the pop-up window.
        /// </summary>
        public PopupAnimations HidingAnimation
        {
            get { return hidingAnimation; }
            set { if (hidingAnimation != value) hidingAnimation = value; }
        }

        private int animationDuration;
        /// <summary>
        /// Determines the duration of the animation.
        /// </summary>
        public int AnimationDuration
        {
            get { return animationDuration; }
            set { if (animationDuration != value) animationDuration = value; }
        }

        private bool focusOnOpen = true;
        /// <summary>
        /// Gets or sets a value indicating whether the content should receive the focus after the pop-up has been opened.
        /// </summary>
        /// <value><c>true</c> if the content should be focused after the pop-up has been opened; otherwise, <c>false</c>.</value>
        /// <remarks>If the FocusOnOpen property is set to <c>false</c>, then pop-up cannot use the fade effect.</remarks>
        public bool FocusOnOpen
        {
            get { return focusOnOpen; }
            set { focusOnOpen = value; }
        }

        private bool acceptAlt = true;
        /// <summary>
        /// Gets or sets a value indicating whether presing the alt key should close the pop-up.
        /// </summary>
        /// <value><c>true</c> if presing the alt key does not close the pop-up; otherwise, <c>false</c>.</value>
        public bool AcceptAlt
        {
            get { return acceptAlt; }
            set { acceptAlt = value; }
        }

        private Control opener;
        private Popup ownerPopup;
        private Popup childPopup;
        private bool resizableTop;
        private bool resizableLeft;

        private bool isChildPopupOpened;
        private bool resizable;
        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="PopupControl.Popup" /> is resizable.
        /// </summary>
        /// <value><c>true</c> if resizable; otherwise, <c>false</c>.</value>
        public bool Resizable
        {
            get { return resizable && !isChildPopupOpened; }
            set { resizable = value; }
        }

        private ToolStripControlHost host;

        private Size minSize;
        /// <summary>
        /// Gets or sets a minimum size of the pop-up.
        /// </summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.</returns>
        public new Size MinimumSize
        {
            get { return minSize; }
            set { minSize = value; }
        }

        private Size maxSize;
        /// <summary>
        /// Gets or sets a maximum size of the pop-up.
        /// </summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.</returns>
        public new Size MaximumSize
        {
            get { return maxSize; }
            set { maxSize = value; }
        }

        /// <summary>
        /// Gets parameters of a new window.
        /// </summary>
        /// <returns>An object of type <see cref="T:System.Windows.Forms.CreateParams" /> used when creating a new window.</returns>
        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= NativeMethods.WS_EX_NOACTIVATE;
                return cp;
            }
        }

        #endregion

        #region " Constructors "

        /// <summary>
        /// Initializes a new instance of the <see cref="PopupControl.Popup"/> class.
        /// </summary>
        /// <param name="content">The content of the pop-up.</param>
        /// <remarks>
        /// Pop-up will be disposed immediately after disposion of the content control.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="content" /> is <code>null</code>.</exception>
        public Popup(Control content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }
            this.content = content;
            showingAnimation = PopupAnimations.SystemDefault;
            hidingAnimation = PopupAnimations.None;
            animationDuration = 100;
            isChildPopupOpened = false;
            InitializeComponent();
            AutoSize = false;
            DoubleBuffered = true;
            ResizeRedraw = true;
            host = new ToolStripControlHost(content);
            Padding = Margin = host.Padding = host.Margin = Padding.Empty;
            MinimumSize = content.MinimumSize;
            content.MinimumSize = content.Size;
            MaximumSize = content.MaximumSize;
            content.MaximumSize = content.Size;
            Size = content.Size;
            TabStop = content.TabStop = true;
            content.Location = Point.Empty;
            Items.Add(host);
            content.Disposed += delegate(object sender, EventArgs e)
            {
                content = null;
                Dispose(true);
            };
            content.RegionChanged += delegate(object sender, EventArgs e)
            {
                UpdateRegion();
            };
            content.Paint += delegate(object sender, PaintEventArgs e)
            {
                PaintSizeGrip(e);
            };
            UpdateRegion();
        }

        #endregion

        #region " Methods "

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripItem.VisibleChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if ((Visible && ShowingAnimation == PopupAnimations.None) || (!Visible && HidingAnimation == PopupAnimations.None))
            {
                return;
            }
            NativeMethods.AnimationFlags flags = Visible ? NativeMethods.AnimationFlags.Roll : NativeMethods.AnimationFlags.Hide;
            PopupAnimations _flags = Visible ? ShowingAnimation : HidingAnimation;
            if (_flags == PopupAnimations.SystemDefault)
            {
                if (SystemInformation.IsMenuAnimationEnabled)
                {
                    if (SystemInformation.IsMenuFadeEnabled)
                    {
                        _flags = PopupAnimations.Blend;
                    }
                    else
                    {
                        _flags = PopupAnimations.Slide | (Visible ? PopupAnimations.TopToBottom : PopupAnimations.BottomToTop);
                    }
                }
                else
                {
                    _flags = PopupAnimations.None;
                }
            }
            if ((_flags & (PopupAnimations.Blend | PopupAnimations.Center | PopupAnimations.Roll | PopupAnimations.Slide)) == PopupAnimations.None)
            {
                return;
            }
            if (resizableTop) // popup is “inverted”, so the animation must be
            {
                if ((_flags & PopupAnimations.BottomToTop) != PopupAnimations.None)
                {
                    _flags = (_flags & ~PopupAnimations.BottomToTop) | PopupAnimations.TopToBottom;
                }
                else if ((_flags & PopupAnimations.TopToBottom) != PopupAnimations.None)
                {
                    _flags = (_flags & ~PopupAnimations.TopToBottom) | PopupAnimations.BottomToTop;
                }
            }
            if (resizableLeft) // popup is “inverted”, so the animation must be
            {
                if ((_flags & PopupAnimations.RightToLeft) != PopupAnimations.None)
                {
                    _flags = (_flags & ~PopupAnimations.RightToLeft) | PopupAnimations.LeftToRight;
                }
                else if ((_flags & PopupAnimations.LeftToRight) != PopupAnimations.None)
                {
                    _flags = (_flags & ~PopupAnimations.LeftToRight) | PopupAnimations.RightToLeft;
                }
            }
            flags = flags | (NativeMethods.AnimationFlags.Mask & (NativeMethods.AnimationFlags)(int)_flags);
            NativeMethods.AnimateWindow(this, AnimationDuration, flags);
        }

        /// <summary>
        /// Processes a dialog box key.
        /// </summary>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>
        /// true if the key was processed by the control; otherwise, false.
        /// </returns>
        [UIPermission(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows)]
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (acceptAlt && ((keyData & Keys.Alt) == Keys.Alt))
            {
                if ((keyData & Keys.F4) != Keys.F4)
                {
                    return false;
                }
                else
                {
                    Close();
                }
            }
            bool processed = base.ProcessDialogKey(keyData);
            if (!processed && (keyData == Keys.Tab || keyData == (Keys.Tab | Keys.Shift)))
            {
                bool backward = (keyData & Keys.Shift) == Keys.Shift;
                Content.SelectNextControl(null, !backward, true, true, true);
            }
            return processed;
        }

        /// <summary>
        /// Updates the pop-up region.
        /// </summary>
        protected void UpdateRegion()
        {
            if (Region != null)
            {
                Region.Dispose();
                Region = null;
            }
            if (content.Region != null)
            {
                Region = content.Region.Clone();
            }
        }

        /// <summary>
        /// Shows the pop-up window below the specified control.
        /// </summary>
        /// <param name="control">The control below which the pop-up will be shown.</param>
        /// <remarks>
        /// When there is no space below the specified control, the pop-up control is shown above it.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="control"/> is <code>null</code>.</exception>
        public void Show(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }
            Show(control, control.ClientRectangle);
        }

        /// <summary>
        /// Shows the pop-up window below the specified area of the specified control.
        /// </summary>
        /// <param name="control">The control used to compute screen location of specified area.</param>
        /// <param name="area">The area of control below which the pop-up will be shown.</param>
        /// <remarks>
        /// When there is no space below specified area, the pop-up control is shown above it.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="control"/> is <code>null</code>.</exception>
        public void Show(Control control, Rectangle area)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }
            SetOwnerItem(control);

            resizableTop = resizableLeft = false;
            Point location = control.PointToScreen(new Point(area.Left, area.Top + area.Height));
            Rectangle screen = Screen.FromControl(control).WorkingArea;
            if (location.X + Size.Width > (screen.Left + screen.Width))
            {
                resizableLeft = true;
                location.X = (screen.Left + screen.Width) - Size.Width;
            }
            if (location.Y + Size.Height > (screen.Top + screen.Height))
            {
                resizableTop = true;
                location.Y -= Size.Height + area.Height;
            }
            location = control.PointToClient(location);
            Show(control, location, ToolStripDropDownDirection.BelowRight);
        }

        private void SetOwnerItem(Control control)
        {
            if (control == null)
            {
                return;
            }
            if (control is Popup)
            {
                Popup popupControl = control as Popup;
                ownerPopup = popupControl;
                ownerPopup.childPopup = this;
                OwnerItem = popupControl.Items[0];
                return;
            }
            else if (opener == null)
            {
                opener = control;
            }
            if (control.Parent != null)
            {
                SetOwnerItem(control.Parent);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            content.MinimumSize = Size;
            content.MaximumSize = Size;
            content.Size = Size;
            content.Location = Point.Empty;
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripDropDown.Opening" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs" /> that contains the event data.</param>
        protected override void OnOpening(CancelEventArgs e)
        {
            if (content.IsDisposed || content.Disposing)
            {
                e.Cancel = true;
                return;
            }
            UpdateRegion();
            base.OnOpening(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripDropDown.Opened" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnOpened(EventArgs e)
        {
            if (ownerPopup != null)
            {
                ownerPopup.isChildPopupOpened = true;
            }
            if (focusOnOpen)
            {
                content.Focus();
            }
            base.OnOpened(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripDropDown.Closed"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripDropDownClosedEventArgs"/> that contains the event data.</param>
        protected override void OnClosed(ToolStripDropDownClosedEventArgs e)
        {
            opener = null;
            if (ownerPopup != null)
            {
                ownerPopup.isChildPopupOpened = false;
            }
            base.OnClosed(e);
        }

        #endregion

        #region " Resizing Support "

        /// <summary>
        /// Processes Windows messages.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            //if (m.Msg == NativeMethods.WM_PRINT && !Visible)
            //{
            //    Visible = true;
            //}
            if (InternalProcessResizing(ref m, false))
            {
                return;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Processes the resizing messages.
        /// </summary>
        /// <param name="m">The message.</param>
        /// <returns>true, if the WndProc method from the base class shouldn't be invoked.</returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool ProcessResizing(ref Message m)
        {
            return InternalProcessResizing(ref m, true);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private bool InternalProcessResizing(ref Message m, bool contentControl)
        {
            if (m.Msg == NativeMethods.WM_NCACTIVATE && m.WParam != IntPtr.Zero && childPopup != null && childPopup.Visible)
            {
                childPopup.Hide();
            }
            if (!Resizable)
            {
                return false;
            }
            if (m.Msg == NativeMethods.WM_NCHITTEST)
            {
                return OnNcHitTest(ref m, contentControl);
            }
            else if (m.Msg == NativeMethods.WM_GETMINMAXINFO)
            {
                return OnGetMinMaxInfo(ref m);
            }
            return false;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private bool OnGetMinMaxInfo(ref Message m)
        {
            NativeMethods.MINMAXINFO minmax = (NativeMethods.MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.MINMAXINFO));
            if (!MaximumSize.IsEmpty)
            {
                minmax.maxTrackSize = MaximumSize;
            }
            minmax.minTrackSize = MinimumSize;
            Marshal.StructureToPtr(minmax, m.LParam, false);
            return true;
        }

        private bool OnNcHitTest(ref Message m, bool contentControl)
        {
            int x = NativeMethods.LOWORD(m.LParam);
            int y = NativeMethods.HIWORD(m.LParam);
            Point clientLocation = PointToClient(new Point(x, y));

            GripBounds gripBouns = new GripBounds(contentControl ? content.ClientRectangle : ClientRectangle);
            IntPtr transparent = new IntPtr(NativeMethods.HTTRANSPARENT);

            if (resizableTop)
            {
                if (resizableLeft && gripBouns.TopLeft.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)NativeMethods.HTTOPLEFT;
                    return true;
                }
                if (!resizableLeft && gripBouns.TopRight.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)NativeMethods.HTTOPRIGHT;
                    return true;
                }
                if (gripBouns.Top.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)NativeMethods.HTTOP;
                    return true;
                }
            }
            else
            {
                if (resizableLeft && gripBouns.BottomLeft.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)NativeMethods.HTBOTTOMLEFT;
                    return true;
                }
                if (!resizableLeft && gripBouns.BottomRight.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)NativeMethods.HTBOTTOMRIGHT;
                    return true;
                }
                if (gripBouns.Bottom.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)NativeMethods.HTBOTTOM;
                    return true;
                }
            }
            if (resizableLeft && gripBouns.Left.Contains(clientLocation))
            {
                m.Result = contentControl ? transparent : (IntPtr)NativeMethods.HTLEFT;
                return true;
            }
            if (!resizableLeft && gripBouns.Right.Contains(clientLocation))
            {
                m.Result = contentControl ? transparent : (IntPtr)NativeMethods.HTRIGHT;
                return true;
            }
            return false;
        }

        private VS.VisualStyleRenderer sizeGripRenderer;
        /// <summary>
        /// Paints the sizing grip.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs" /> instance containing the event data.</param>
        public void PaintSizeGrip(PaintEventArgs e)
        {
            if (e == null || e.Graphics == null || !resizable)
            {
                return;
            }
            Size clientSize = content.ClientSize;
            using (Bitmap gripImage = new Bitmap(0x10, 0x10))
            {
                using (Graphics g = Graphics.FromImage(gripImage))
                {
                    if (Application.RenderWithVisualStyles)
                    {
                        if (sizeGripRenderer == null)
                        {
                            sizeGripRenderer = new VS.VisualStyleRenderer(VS.VisualStyleElement.Status.Gripper.Normal);
                        }
                        sizeGripRenderer.DrawBackground(g, new Rectangle(0, 0, 0x10, 0x10));
                    }
                    else
                    {
                        ControlPaint.DrawSizeGrip(g, content.BackColor, 0, 0, 0x10, 0x10);
                    }
                }
                GraphicsState gs = e.Graphics.Save();
                e.Graphics.ResetTransform();
                if (resizableTop)
                {
                    if (resizableLeft)
                    {
                        e.Graphics.RotateTransform(180);
                        e.Graphics.TranslateTransform(-clientSize.Width, -clientSize.Height);
                    }
                    else
                    {
                        e.Graphics.ScaleTransform(1, -1);
                        e.Graphics.TranslateTransform(0, -clientSize.Height);
                    }
                }
                else if (resizableLeft)
                {
                    e.Graphics.ScaleTransform(-1, 1);
                    e.Graphics.TranslateTransform(-clientSize.Width, 0);
                }
                e.Graphics.DrawImage(gripImage, clientSize.Width - 0x10, clientSize.Height - 0x10 + 1, 0x10, 0x10);
                e.Graphics.Restore(gs);
            }
        }

        #endregion
    }

    internal static class NativeMethods
    {
        internal const int WM_NCHITTEST = 0x0084,
                           WM_NCACTIVATE = 0x0086,
                           WS_EX_NOACTIVATE = 0x08000000,
                           HTTRANSPARENT = -1,
                           HTLEFT = 10,
                           HTRIGHT = 11,
                           HTTOP = 12,
                           HTTOPLEFT = 13,
                           HTTOPRIGHT = 14,
                           HTBOTTOM = 15,
                           HTBOTTOMLEFT = 16,
                           HTBOTTOMRIGHT = 17,
                           WM_PRINT = 0x0317,
                           WM_USER = 0x0400,
                           WM_REFLECT = WM_USER + 0x1C00,
                           WM_COMMAND = 0x0111,
                           CBN_DROPDOWN = 7,
                           WM_GETMINMAXINFO = 0x0024;


        [Flags]
        internal enum AnimationFlags : int
        {
            Roll = 0x0000, // Uses a roll animation.
            HorizontalPositive = 0x00001, // Animates the window from left to right. This flag can be used with roll or slide animation.
            HorizontalNegative = 0x00002, // Animates the window from right to left. This flag can be used with roll or slide animation.
            VerticalPositive = 0x00004, // Animates the window from top to bottom. This flag can be used with roll or slide animation.
            VerticalNegative = 0x00008, // Animates the window from bottom to top. This flag can be used with roll or slide animation.
            Center = 0x00010, // Makes the window appear to collapse inward if <c>Hide</c> is used or expand outward if the <c>Hide</c> is not used.
            Hide = 0x10000, // Hides the window. By default, the window is shown.
            Activate = 0x20000, // Activates the window.
            Slide = 0x40000, // Uses a slide animation. By default, roll animation is used.
            Blend = 0x80000, // Uses a fade effect. This flag can be used only with a top-level window.
            Mask = 0xfffff,
        }

        [SuppressUnmanagedCodeSecurity]
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int AnimateWindow(HandleRef windowHandle, int time, AnimationFlags flags);

        internal static void AnimateWindow(Control control, int time, AnimationFlags flags)
        {
            try
            {
                SecurityPermission sp = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
                sp.Demand();
                AnimateWindow(new HandleRef(control, control.Handle), time, flags);
            }
            catch (SecurityException) { }
        }

        internal static int HIWORD(int n)
        {
            return (n >> 16) & 0xffff;
        }

        internal static int HIWORD(IntPtr n)
        {
            return HIWORD(unchecked((int)(long)n));
        }

        internal static int LOWORD(int n)
        {
            return n & 0xffff;
        }

        internal static int LOWORD(IntPtr n)
        {
            return LOWORD(unchecked((int)(long)n));
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MINMAXINFO
        {
            public Point reserved;
            public Size maxSize;
            public Point maxPosition;
            public Size minTrackSize;
            public Size maxTrackSize;
        }
    }

    internal struct GripBounds
    {
        private const int GripSize = 6;
        private const int CornerGripSize = GripSize << 1;

        public GripBounds(Rectangle clientRectangle)
        {
            this.clientRectangle = clientRectangle;
        }

        private Rectangle clientRectangle;
        public Rectangle ClientRectangle
        {
            get { return clientRectangle; }
            //set { clientRectangle = value; }
        }

        public Rectangle Bottom
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Y = rect.Bottom - GripSize + 1;
                rect.Height = GripSize;
                return rect;
            }
        }

        public Rectangle BottomRight
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Y = rect.Bottom - CornerGripSize + 1;
                rect.Height = CornerGripSize;
                rect.X = rect.Width - CornerGripSize + 1;
                rect.Width = CornerGripSize;
                return rect;
            }
        }

        public Rectangle Top
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Height = GripSize;
                return rect;
            }
        }

        public Rectangle TopRight
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Height = CornerGripSize;
                rect.X = rect.Width - CornerGripSize + 1;
                rect.Width = CornerGripSize;
                return rect;
            }
        }

        public Rectangle Left
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Width = GripSize;
                return rect;
            }
        }

        public Rectangle BottomLeft
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Width = CornerGripSize;
                rect.Y = rect.Height - CornerGripSize + 1;
                rect.Height = CornerGripSize;
                return rect;
            }
        }

        public Rectangle Right
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.X = rect.Right - GripSize + 1;
                rect.Width = GripSize;
                return rect;
            }
        }

        public Rectangle TopLeft
        {
            get
            {
                Rectangle rect = ClientRectangle;
                rect.Width = CornerGripSize;
                rect.Height = CornerGripSize;
                return rect;
            }
        }
    }

    /// <summary>
    /// Types of animation of the pop-up window.
    /// </summary>
    [Flags]
    public enum PopupAnimations : int
    {
        /// <summary>
        /// Uses no animation.
        /// </summary>
        None = 0,
        /// <summary>
        /// Animates the window from left to right. This flag can be used with roll or slide animation.
        /// </summary>
        LeftToRight = 0x00001,
        /// <summary>
        /// Animates the window from right to left. This flag can be used with roll or slide animation.
        /// </summary>
        RightToLeft = 0x00002,
        /// <summary>
        /// Animates the window from top to bottom. This flag can be used with roll or slide animation.
        /// </summary>
        TopToBottom = 0x00004,
        /// <summary>
        /// Animates the window from bottom to top. This flag can be used with roll or slide animation.
        /// </summary>
        BottomToTop = 0x00008,
        /// <summary>
        /// Makes the window appear to collapse inward if it is hiding or expand outward if the window is showing.
        /// </summary>
        Center = 0x00010,
        /// <summary>
        /// Uses a slide animation.
        /// </summary>
        Slide = 0x40000,
        /// <summary>
        /// Uses a fade effect.
        /// </summary>
        Blend = 0x80000,
        /// <summary>
        /// Uses a roll animation.
        /// </summary>
        Roll = 0x100000,
        /// <summary>
        /// Uses a default animation.
        /// </summary>
        SystemDefault = 0x200000,
    }
}
