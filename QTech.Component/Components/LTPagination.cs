using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using EasyServer.Domain.Helpers;
using QTech.Component.Properties;

namespace QTech.Component
{
    [DefaultEvent("DataSourceChanged")]
    public partial class LTPagination : UserControl
    {
        public delegate void EventHandlerDataSourceChanged(object sender, EventArgs e);
        public event EventHandlerDataSourceChanged DataSourceChanged;
        public LTPagination()
        {
            InitializeComponent();

            lblFirst.Tag = false;
            lblLeft.Tag = false;
            lblCurrent.Tag = false;
            lblRight.Tag = false;
            lblLast.Tag = false;
            //Set font
            lblCurrent.Font = lblFirst.Font = lblGo_.Font = lblMoreRight.Font = lblNext.Font = lblPrevious.Font = lblRight.Font = lblMoreLeft.Font = new Font("Fasthand", 8);

        }

        private Color _backGroundColor = Color.Blue;
        public Color BackGroundColor {
            get => _backGroundColor;
            set {
                if (value != null)
                {
                    _backGroundColor = value;
                    this.BackColor = value;
                }
            } 
        }

        private bool _event = false;
        protected override void OnCreateControl()
        {
            if (!DesignMode && !_event)
            {
                var keyUp = true;
                lblFirst.Paint += (s, e) => DrawPlus(e, lblFirst);
                lblLeft.Paint += (s, e) => DrawPlus(e, lblLeft);
                lblCurrent.Paint += (s, e) => DrawPlus(e, lblCurrent);
                lblRight.Paint += (s, e) => DrawPlus(e, lblRight);
                lblLast.Paint += (s, e) => DrawPlus(e, lblLast);

                lblPrevious.Click += (s, e) =>
                {
                    if (_currentPage > 1)
                        CurrentPage = _currentPage - 1;
                };
                lblFirst.Click += (s, e) => { if (!_isBusy) CurrentPage = 1; };
                lblLeft.Click += (s, e) => { if (!_isBusy) CurrentPage = _currentPage - 1; };
                lblRight.Click += (s, e) => { if (!_isBusy) CurrentPage = _currentPage + 1; };
                lblLast.Click += (s, e) => { if (!_isBusy) CurrentPage = _pageCount; };
                lblNext.Click += (s, e) =>
                {
                    if (!_isBusy && _currentPage < _pageCount)
                        CurrentPage = _currentPage + 1;
                };
                txtPage.Enter += (s, e) => txtPage.SelectAll();
                txtPage.Leave += (s, e) => txtPage.Text = _currentPage.ToString();
                txtPage.KeyPress += (s, e) =>
                {
                    if (e.KeyChar == (char)Keys.Enter && keyUp)
                    {
                        ChangePage(Parse.ToInt(txtPage.Text));
                        txtPage.SelectionStart = txtPage.TextLength;
                        keyUp = false;
                    }
                    if (Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
                    {
                        e.Handled = true;
                    }
                    else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                };
                txtPage.KeyUp += (s, e) => keyUp = true;
                lblGo_.Click += (s, e) => ChangePage(Parse.ToInt(txtPage.Text));
                _event = true;
            }
            if (!DesignMode)
            {
                this.Cursor = lblCurrent.Cursor = lblMoreLeft.Cursor = lblMoreRight.Cursor = Cursors.Arrow;
                lblPrevious.Cursor = lblNext.Cursor = lblFirst.Cursor = lblLeft.Cursor = lblRight.Cursor = lblLast.Cursor = lblGo_.Cursor = Cursors.Hand;
                txtPage.Cursor = Cursors.IBeam;
            }
            base.OnCreateControl();
        }
        private bool isFirstLoad = true;
        private IQueryable<QTech.Base.BaseModel> _dataSourceFn;
        public IQueryable<QTech.Base.BaseModel> DataSourceFn
        {
            set
            {
                _dataSourceFn = value;
                ChangePaginationCount(1);
            }
        }

        private IQueryable<QTech.Base.BaseModel> _dataSource;
        public IQueryable<QTech.Base.BaseModel> DataSource
        {
            get { return _dataSource; }
        }

        public int Paging = 30;

        private int _currentPage = 1;
        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                ChangePage(_currentPage);
            }
        }

        private int _pageCount = 5;
        public int PageCount
        {
            get { return _pageCount; }
        }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
        }

        private int _oldPage = 1;
        public int OldPage
        {
            get { return _oldPage; }
        }

        private int _recordCount = 0;
        public int RecordCount
        {
            get { return _recordCount; }
        }

        public void SetCurrentPage(int currentPage, bool isLoadEvent = false)
        {
            ChangePage(currentPage, isLoadEvent);
        }

        public void RefreshCurrentPage(bool isLoadEvent = false)
        {
            ChangePage(_currentPage, isLoadEvent);
        }

        public void Reload()
        {
            ChangePaginationCount(1);

        }

        private void SetLeftPage()
        {
            if (_currentPage == 1)
            {
                lblPrevious.Cursor = DesignMode ? Cursors.Default : Cursors.Arrow;
                lblPrevious.Image = Resources.imgNonePreviousPage;
                lblFirst.Visible = lblMoreLeft.Visible = lblLeft.Visible = false;
            }
            else
            {
                if (lblPrevious.Cursor != ( DesignMode ? Cursors.Hand : Cursors.Hand))
                {
                    lblPrevious.Cursor = (DesignMode ? Cursors.Hand : Cursors.Hand);
                    lblPrevious.Image = Resources.imgPreviousPage;
                }
                if (_currentPage - 1 == 1)
                {
                    lblFirst.Visible = lblMoreLeft.Visible = false;
                    lblLeft.Visible = true;
                    SetLabel(lblLeft, _currentPage - 1, false);
                }
                else if (_currentPage - 1 == 2)
                {
                    lblMoreLeft.Visible = false;
                    lblFirst.Visible = lblLeft.Visible = true;
                    SetLabel(lblLeft, _currentPage - 1, false);
                }
                else if (_currentPage - 1 > 2)
                {
                    lblFirst.Visible = lblMoreLeft.Visible = lblLeft.Visible = true;
                    SetLabel(lblLeft, _currentPage - 1, false);
                }
            }
        }

        private void SetRightPage()
        {
            if (_pageCount == _currentPage)
            {
                lblNext.Cursor = DesignMode ? Cursors.Default : Cursors.Arrow;
                lblNext.Image = Resources.imgNoneNextPage;
                lblRight.Visible = lblMoreRight.Visible = lblLast.Visible = false;
            }
            else
            {
                if (lblNext.Cursor != (DesignMode ? Cursors.Hand : Cursors.Hand))
                {
                    lblNext.Cursor = (DesignMode ? Cursors.Hand : Cursors.Hand);
                    lblNext.Image = Resources.imgNextPage;
                }

                if (_pageCount - _currentPage == 1)
                {
                    SetLabel(lblRight, _pageCount, false);
                    lblRight.Visible = true;
                    lblMoreRight.Visible = lblLast.Visible = false;
                }
                else if (_pageCount - _currentPage == 2)
                {
                    lblMoreRight.Visible = false;
                    SetLabel(lblRight, _currentPage + 1, false);
                    SetLabel(lblLast, _pageCount, false);
                    lblRight.Visible = lblLast.Visible = true;
                }
                else if (_pageCount - _currentPage > 2)
                {
                    SetLabel(lblRight, _currentPage + 1, false);
                    SetLabel(lblLast, _pageCount, false);
                    lblRight.Visible = lblMoreRight.Visible = lblLast.Visible = true;
                }
            }
        }

        private void SetLabel(Label lbl, int value, bool active)
        {
            if (value <= 99)
            {
                lbl.Tag = false;
                lbl.Text = value.ToString();
            }
            else
            {
                lbl.Tag = true;
                lbl.Text = "99";
            }

            if (active)
            {
                lbl.Image = Resources.imgCurrentBack;
            }
            else
            {
                lbl.Image = Resources.imgPaginationBack;
            }
        }

        private void DrawPlus(PaintEventArgs e, Label lbl)
        {
            var draw = (bool)lbl.Tag;
            if (draw)
            {
                var drawString = "+";
                var drawFont = new Font("Times New Roman", 8F);
                var drawBrush = new SolidBrush(Color.Red);

                float x = lbl.Width - 9;
                float y = -2;

                var drawFormat = new StringFormat
                {
                    FormatFlags = StringFormatFlags.DisplayFormatControl
                };
                e.Graphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
            }
        }

        private void ChangeChildIndex()
        {
            flpMain.Controls.SetChildIndex(lblFirst, 1);
            flpMain.Controls.SetChildIndex(lblMoreLeft, 2);
            flpMain.Controls.SetChildIndex(lblLeft, 3);
            flpMain.Controls.SetChildIndex(lblCurrent, 4);
            flpMain.Controls.SetChildIndex(lblRight, 5);
            flpMain.Controls.SetChildIndex(lblMoreRight, 6);
            flpMain.Controls.SetChildIndex(lblLast, 7);
            flpMain.Controls.SetChildIndex(lblNext, 8);
            flpMain.Controls.SetChildIndex(txtPage, 9);
            flpMain.Controls.SetChildIndex(lblGo_, 10);
            flpMain.Controls.SetChildIndex(picLoading, 11);
        }

        private void ChangePaginationCount(int currentPage)
        {
            if (_isBusy) return;
            if (_dataSourceFn != null)
            {
                try
                {
                    _isBusy = true;
                    picLoading.Visible = true;
                    int count = _dataSourceFn.Count();
                    _recordCount = count;
                    int pageCount = (count / Paging);
                    if (count % Paging > 0)
                        pageCount++;
                    if (pageCount == 0)
                        pageCount = 1;
                    _pageCount = pageCount;
                    ChangePage(currentPage);

                }
                catch (Exception ex)
                {
                    MsgBox.ShowError(ex);
                }
                finally { _isBusy = false; picLoading.Visible = false; }
            }
        }

        private void ChangePage(int currentPage, bool loadEvent = true)
        {
            txtPage.Text = currentPage.ToString();
            _currentPage = currentPage;
            if (currentPage <= 0)
            {
                _currentPage = 1;
                ChangePage(1);
                return;
            }
            if (currentPage > _pageCount)
            {
                _currentPage = _pageCount;
                ChangePage(_currentPage);
                return;
            }
            SetLabel(lblCurrent, currentPage, true);
            SetLeftPage();
            SetRightPage();
            ChangeChildIndex();

            if (_dataSourceFn == null) return;
            _dataSource = _dataSourceFn.OrderByDescending(x=>x.RowDate).Skip((_currentPage - 1) * Paging).Take(Paging);
            if (loadEvent && DataSourceChanged != null)
                DataSourceChanged(this, new EventArgs());
        }
    }
}
