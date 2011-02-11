﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mono.Cecil;
using System.Reflection;

namespace Monoflector
{
    public partial class AssemblyProviderSelection : UserControl
    {
        public event EventHandler CloseRequested;
        private AssemblySet _set;
        private Color _defaultColor;

        private IAssemblyProvider _provider;
        public AssemblyProviderSelection()
        {
            InitializeComponent();
        }
        
        public AssemblyProviderSelection(IAssemblyProvider provider, AssemblySet set)
            : this()
        {
            _provider = provider;
            _set = set;
            if (_provider != null)
            {
                _provider.AssemblyDiscovered += provider_AssemblyDiscovered;
                _provider.Start();
            }
        }

        private void _closeButton_Click(object sender, EventArgs e)
        {
            var tmp = CloseRequested;
            if (tmp != null)
                CloseRequested(this, e);
        }

        private void UpdateColumns()
        {
            var area = _assembliesListView.ClientSize.Width;
            area -= _iconHeader.Width;
            area -= _versionHeader.Width;
            area -= _architectureHeader.Width;
            _nameColumn.Width = area;
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            UpdateColumns();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateColumns();
            base.OnSizeChanged(e);
        }

        protected override void OnResize(EventArgs e)
        {
            UpdateColumns();
            base.OnResize(e);
        }

        void provider_AssemblyDiscovered(object sender, ValueEventArgs<ILightAssembly> e)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new EventHandler<ValueEventArgs<ILightAssembly>>(provider_AssemblyDiscovered), sender, e);
                return;
            }

            var lvi = new ListViewItem(new string[] { null, e.Value.Name, e.Value.Version.ToString(), e.Value.ProcessorArchitecture.ToLocalString() });
            lvi.Text = e.Value.Name.ToLowerInvariant();
            lvi.Tag = e.Value;
            lvi.ImageIndex = _set.Contains(e.Value) ? 0 : -1;
            _defaultColor = lvi.BackColor;

            _assembliesListView.Items.Add(lvi);
        }

        #region List View Handling
        private void _addButton_Click(object sender, EventArgs e)
        {
            if (_assembliesListView.SelectedItems.Count == 0)
                return;
            foreach (ListViewItem item in _assembliesListView.SelectedItems)
            {
                var asm = (ILightAssembly)item.Tag;
                if (_set.Contains(asm))
                {
                    _set.Remove(asm);
                    item.ImageIndex = -1;
                }
                else
                {
                    _set.Add(asm);
                    item.ImageIndex = 0;
                }
            }
            UpdateButtons();
            _assembliesListView.Invalidate();
        }

        private void _assembliesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            if (_assembliesListView.SelectedItems.Count == 0)
            {
                _addButton.Enabled = false;
                return;
            }

            bool add = false;
            bool remove = false;

            foreach (ListViewItem item in _assembliesListView.SelectedItems)
            {
                var asm = (ILightAssembly)item.Tag;
                if (_set.Contains(asm))
                {
                    remove = true;
                }
                else
                {
                    add = true;
                }
                if (add && remove)
                    break;
            }

            if (add && remove)
                _addButton.Enabled = false;
            else
            {
                _addButton.Enabled = true;
                if (add)
                {
                    _addButton.Text = "&Add";
                    _addButton.Image = Properties.Resources.add;
                }
                else
                {
                    _addButton.Text = "&Remove";
                    _addButton.Image = Properties.Resources.delete;
                }
            }
        } 
        #endregion

        protected override void OnParentChanged(EventArgs e)
        {
            if (Parent == null)
            {
                CloseRequested = null;
                _provider.AssemblyDiscovered -= provider_AssemblyDiscovered;
            }
            base.OnParentChanged(e);
        }

        private void _filterTextBox_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void _searchTimer_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_filterTextBox.Text))
            {
                var searchTerm = _filterTextBox.Text.ToLowerInvariant();
                foreach (ListViewItem item in _assembliesListView.Items)
                {
                    var match = item.Text.Contains(searchTerm);
                    if (match)
                    {
                        item.EnsureVisible();
                    }

                    if (match && !item.Selected)
                    {
                        item.BackColor = SystemColors.HotTrack;
                        item.ForeColor = SystemColors.HighlightText;
                    }
                    else if (!match && item.Selected)
                    {
                        item.BackColor = SystemColors.Window;
                        item.ForeColor = SystemColors.WindowText;
                    }
                }
            }
            _searchTimer.Stop();
            _assembliesListView.Invalidate();
        }
    }
}
