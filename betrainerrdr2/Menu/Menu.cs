﻿///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BETrainerRdr2.Menu
{
    /// <summary>
    /// Menu
    /// </summary>
    public class Menu
    {
        // Page format
        private const string PAGE_FORMAT = "{0} / {1}";

        private const string TOGGLE_BRACE = "[     ]";

        // On
        private static readonly MLString TOGGLE_ON = Utils.CSML(" On", "  開");
        private static readonly Color TOGGLE_ON_COLOR = Color.LightGreen;
        private static readonly Color TOGGLE_ON_COLOR_SELECTED = Color.DarkGreen;

        // Off
        private static readonly MLString TOGGLE_OFF = Utils.CSML(" Off", "  關");
        private static readonly Color TOGGLE_OFF_COLOR = Color.Red;
        private static readonly Color TOGGLE_OFF_COLOR_SELECTED = Color.DarkRed;

        // Has sub menu sign
        private const string HAS_SUBMENU = ">>";

        // Left/right adjustable sign
        private const string LEFT_RIGHT_ADJUSTABLE = "<->";

        /// <summary>
        /// Gets or sets the location of the top-left point of the menu in pixel
        /// </summary>
        public Point Location = new Point(10, 10);

        /// <summary>
        /// Gets or sets a value indicating whether play a beep sound when moving cursor
        /// </summary>
        public bool PlayBeep = true;

        /// <summary>
        /// Menu title
        /// </summary>
        public MLString Title = null;

        /// <summary>
        /// Menu title offset
        /// </summary>
        public Point TitleShadowDistance = new Point();

        /// <summary>
        /// Menu title shadow color
        /// </summary>
        public Color TitleShadowColor = Color.Black;

        /// <summary>
        /// Menu title text color
        /// </summary>
        public Color TitleTextColor = Color.Yellow;

        /// <summary>
        /// Menu title back color
        /// </summary>
        public Color TitleBackColor = Color.FromArgb(192, Color.Black);

        // Menu title height in pixel
        private int _titleHeight = 50;

        /// <summary>
        /// Gets or sets the title height
        /// </summary>
        public int TitleHeight
        {
            get
            {
                return _titleHeight;
            }
            set
            {
                _titleHeight = value;
            }
        }

        /// <summary>
        /// Menu title font
        /// </summary>
        public RDR2.UI.Font TitleFont = RDR2.UI.Font.ChaletLondon;

        // Menu title text x scale
        private float _titleScale = 0.4f;

        /// <summary>
        /// Gets or sets the title text scale
        /// </summary>
        public float TitleScale
        {
            get
            {
                return _titleScale;
            }
            set
            {
                _titleScale = value;
                if (_titleScale < 0f) _titleScale = 0f;
            }
        }

        /// <summary>
        /// Menu title alignment
        /// </summary>
        public GlobalConst.HAlignment TitleAlign = GlobalConst.HAlignment.Left;

        // Menu items
        private List<MenuItem> _items = null;

        // Selected index
        private int _selectedIndex = 0;

        // Current page
        private int _page = 1;

        // Menu width
        private int _width = 350;

        // Menu item height
        private int _itemHeight = 50;

        // Screen width
        private int _screenWidth = GlobalConst.DEFAULT_SCREEN_WIDTH;

        // Screen height
        private int _screenHeight = GlobalConst.DEFAULT_SCREEN_HEIGHT;

        // Item count per page
        private int _itemPerPage = 12;

        // Menu item horizontal spacing in pixel
        private int _itemSpacing = 2;

        /// <summary>
        /// Gets or sets the title text offset
        /// </summary>
        public Point TitleOffset = new Point(10, 8);

        /// <summary>
        /// Gets or sets the page text offset
        /// </summary>
        public Point PageTextOffset = new Point(280, 8);

        /// <summary>
        /// Gets or sets the toggle text offset
        /// </summary>
        public Point ToggleTextOffset = new Point(300, 8);

        /// <summary>
        /// Gets or sets the has submenu sign offset
        /// </summary>
        public Point HasSubmenuSignOffset = new Point(315, 8);

        /// <summary>
        /// Gets or sets the left/right adjustable sign offset
        /// </summary>
        public Point LeftRightAdjustableSignOffset = new Point(310, 8);

        /// <summary>
        /// Gets menu item count
        /// </summary>
        public int ItemCount
        {
            get
            {
                if (_items != null) return _items.Count;
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the horizontal spacing in pixel for each menu item 
        /// </summary>
        public int ItemSpacing
        {
            get
            {
                return _itemSpacing;
            }
            set
            {
                _itemSpacing = value;
            }
        }

        /// <summary>
        /// Gets or sets the item count per page
        /// </summary>
        public int ItemPerPage
        {
            get
            {
                return _itemPerPage;
            }
            set
            {
                _itemPerPage = value;
                if (_itemPerPage < 1) _itemPerPage = 1;
            }
        }

        /// <summary>
        /// Gets or sets the screen width in pixel
        /// </summary>
        public int ScreenWidth
        {
            get
            {
                return _screenWidth;
            }
            set
            {
                _screenWidth = value;
                if (_screenWidth < 1) _screenWidth = 1;
            }
        }

        /// <summary>
        /// Gets or sets the screen height in pixel
        /// </summary>
        public int ScreenHeight
        {
            get
            {
                return _screenHeight;
            }
            set
            {
                _screenHeight = value;
                if (_screenHeight < 1) _screenHeight = 1;
            }
        }

        /// <summary>
        /// Gets or sets the width of this menu in pixel
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value > 0) _width = value;
                else _width = 1;
            }
        }

        /// <summary>
        /// Gets or sets the item height of this menu in pixel
        /// </summary>
        public int ItemHeight
        {
            get
            {
                return _itemHeight;
            }
            set
            {
                if (value > 0) _itemHeight = value;
                else _itemHeight = 1;
            }
        }

        /// <summary>
        /// Gets the total page count of this menu.
        /// </summary>
        public int PageCount
        {
            get
            {
                if (_items.Count == 0) return 1;
                return (_items.Count - 1) / _itemPerPage + 1;
            }
        }

        /// <summary>
        /// Gets or sets the current page of this menu.
        /// </summary>
        public int Page
        {
            get
            {
                return _page;
            }
            set
            {
                if (value < 1)
                {
                    _page = 1;
                }
                else if (value > PageCount)
                {
                    _page = PageCount;
                }
                else
                {
                    _page = value;
                }
                EnsureSelectedIndexInCurrentPage();
            }
        }

        /// <summary>
        /// Gets or sets the selected index of this menu.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                if (value < 0)
                {
                    _selectedIndex = 0;
                }
                else if (value >= _items.Count)
                {
                    _selectedIndex = _items.Count - 1;
                }
                else
                {
                    _selectedIndex = value;
                }
                _page = GetPageBySelectedIndex();
            }
        }

        /// <summary>
        /// Creates an instance of a menu.
        /// </summary>
        /// <param name="title">Title of the menu</param>
        public Menu(MLString title)
        {
            Title = title;
            _items = new List<MenuItem>();
            Debug.Log("Created Menu: {0}", title);
        }

        /// <summary>
        /// Creates an instance of a menu.
        /// </summary>
        /// <param name="title">Title of the menu</param>
        /// <param name="x">X position of the menu</param>
        /// <param name="y">Y position of the menu</param>
        public Menu(MLString title, int x, int y)
            : this(title, new Point(x, y))
        {
        }

        /// <summary>
        /// Creates an instance of a menu.
        /// </summary>
        /// <param name="title">Title of menu</param>
        /// <param name="location">Location of the menu</param>
        public Menu(MLString title, Point location)
            : this(title)
        {
            Location = location;
        }

        /// <summary>
        /// Creates an instance of a menu and adds initial items.
        /// </summary>
        /// <param name="title">Title of menu</param>
        /// <param name="x">X position of the menu</param>
        /// <param name="y">Y position of the menu</param>
        /// <param name="items">Menu items</param>
        public Menu(MLString title, int x, int y, MenuItem[] items)
            : this(title, new Point(x, y), items)
        {
        }

        /// <summary>
        /// Creates an instance of a menu and adds initial items.
        /// </summary>
        /// <param name="title">Title of menu</param>
        /// <param name="location">Location of the menu</param>
        /// <param name="items">Menu items</param>
        public Menu(MLString title, Point location, MenuItem[] items)
            : this(title)
        {
            _items.AddRange(items);
            Location = location;
        }

        /// <summary>
        /// Creates an instance of menu and set initial values.
        /// </summary>
        /// <param name="title">Title of menu</param>
        /// <param name="x">X position of the menu</param>
        /// <param name="y">Y position of the menu</param>
        /// <param name="width">Width of the menu in pixel</param>
        /// <param name="itemHeight">Item height of the menu in pixel</param>
        /// <param name="itemPerPage">Item count per page</param>
        public Menu(MLString title, int x, int y, int width, int itemHeight, int itemPerPage)
            : this(title, new Point(x, y), width, itemHeight, itemPerPage)
        {
        }

        /// <summary>
        /// Creates an instance of menu and set initial values.
        /// </summary>
        /// <param name="title">Title of menu</param>
        /// <param name="location">Location of the menu</param>
        /// <param name="width">Width of the menu in pixel</param>
        /// <param name="itemHeight">Item height of the menu in pixel</param>
        /// <param name="itemPerPage">Item count per page</param>
        public Menu(MLString title, Point location, int width, int itemHeight, int itemPerPage)
            : this(title)
        {
            _width = width;
            _itemHeight = itemHeight;
            _itemPerPage = itemPerPage;
            Location = location;
        }

        /// <summary>
        /// Creates an instance of menu and set initial values.
        /// </summary>
        /// <param name="title">Title of menu</param>
        /// <param name="x">X position of the menu</param>
        /// <param name="y">Y position of the menu</param>
        /// <param name="width">Width of the menu in pixel</param>
        /// <param name="itemHeight">Item height of the menu in pixel</param>
        /// <param name="screenWidth">Screen width in pixel</param>
        /// <param name="screenHeight">Screen height in pixel</param>
        /// <param name="itemPerPage">Item count per page</param>
        public Menu(MLString title, int x, int y, int width, int itemHeight, int screenWidth, int screenHeight, int itemPerPage)
            : this(title, new Point(x, y), width, itemHeight, screenWidth, screenHeight, itemPerPage)
        {
        }

        /// <summary>
        /// Creates an instance of menu and set initial values.
        /// </summary>
        /// <param name="title">Title of menu</param>
        /// <param name="location">Location of the menu</param>
        /// <param name="width">Width of the menu in pixel</param>
        /// <param name="itemHeight">Item height of the menu in pixel</param>
        /// <param name="screenWidth">Screen width in pixel</param>
        /// <param name="screenHeight">Screen height in pixel</param>
        /// <param name="itemPerPage">Item count per page</param>
        public Menu(MLString title, Point location, int width, int itemHeight, int screenWidth, int screenHeight, int itemPerPage)
            : this(title)
        {
            _width = width;
            _itemHeight = itemHeight;
            _screenHeight = screenHeight;
            _screenWidth = screenWidth;
            _itemPerPage = itemPerPage;
            Location = location;
        }

        /// <summary>
        /// Creates an instance of menu and set initial values.
        /// </summary>
        /// <param name="title">Title of menu</param>
        /// <param name="location">Location of the menu</param>
        /// <param name="width">Width of the menu in pixel</param>
        /// <param name="itemHeight">Item height of the menu in pixel</param>
        /// <param name="screenWidth">Screen width in pixel</param>
        /// <param name="screenHeight">Screen height in pixel</param>
        /// <param name="itemPerPage">Item count per page</param>
        /// <param name="items">Menu items</param>
        public Menu(MLString title, Point location, int width, int itemHeight, int screenWidth, int screenHeight, int itemPerPage, MenuItem[] items)
            : this(title, location, items)
        {
            _width = width;
            _itemHeight = itemHeight;
            _screenHeight = screenHeight;
            _screenWidth = screenWidth;
            _itemPerPage = itemPerPage;
        }

        /// <summary>
        /// Adds a menu item into this menu.
        /// </summary>
        /// <param name="item">Menu item</param>
        public void Add(MenuItem item)
        {
            if (item != null) _items.Add(item);
            item.Index = _items.Count - 1;
            item.Parent = this;
            EnsurePage();
            EnsureSelectedIndexInCurrentPage();
        }

        /// <summary>
        /// Adds many menu items into this menu.
        /// </summary>
        /// <param name="items">Menu items</param>
        public void Add(MenuItem[] items)
        {
            _items.AddRange(items);
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].Index = i;
            }
            EnsurePage();
            EnsureSelectedIndexInCurrentPage();
        }

        /// <summary>
        /// Gets or sets the selected menu item of this menu.
        /// </summary>
        public MenuItem SelectedItem
        {
            get
            {
                if (_selectedIndex >= 0 && _selectedIndex < _items.Count) return _items[_selectedIndex];
                else return null;
            }
            set
            {
                if (value == null)
                {
                    _items.RemoveAt(_selectedIndex);
                    EnsurePage();
                    EnsureSelectedIndexInCurrentPage();
                }
                else
                {
                    _items[_selectedIndex] = value;
                }
            }
        }

        /// <summary>
        /// Gets the specified menu item
        /// </summary>
        /// <param name="index">Index of the menu item</param>
        /// <returns></returns>
        public MenuItem GetMenuItem(int index)
        {
            if (index >= 0 && index < _items.Count) return _items[index];
            else return null;
        }

        /// <summary>
        /// Removes the specified menu item
        /// </summary>
        /// <param name="menuItem">Menu item object</param>
        public void Remove(MenuItem menuItem)
        {
            if (_items.Contains(menuItem))
            {
                _items.Remove(menuItem);
                EnsurePage();
                EnsureSelectedIndexInCurrentPage();
            }
        }

        /// <summary>
        /// Removes specified menu item
        /// </summary>
        /// <param name="index">Index of menu item</param>
        public void Remove(int index)
        {
            if (index >= 0 && index < _items.Count)
            {
                _items[index].Parent = null;
                _items.RemoveAt(index);
                EnsurePage();
                EnsureSelectedIndexInCurrentPage();
            }
        }

        /// <summary>
        /// Removes all menu items
        /// </summary>
        public void Clear()
        {
            foreach (MenuItem mi in _items)
            {
                mi.Parent = null;
            }
            _items.Clear();
            _selectedIndex = 0;
        }

        /// <summary>
        /// Activate current menu item
        /// </summary>
        public void Activate()
        {
            if (SelectedItem != null) SelectedItem.OnActivated();
            if (PlayBeep) MenuStorage.PlayMenuBeep();
        }

        /// <summary>
        /// Moves the cursor down one item
        /// </summary>
        public void MoveDown()
        {
            int oldSelectedIndex = _selectedIndex;
            int fi = GetFirstItemIndexInCurrentPage();
            int li = GetLastItemIndexInCurrentPage();
            _selectedIndex++;
            if (_selectedIndex > li) _selectedIndex = fi;
            if (oldSelectedIndex != _selectedIndex && SelectedItem != null)
            {
                if (PlayBeep) MenuStorage.PlayMenuBeep();
                SelectedItem.OnHighlighted();
            }
        }

        /// <summary>
        /// Moves the cursor up one item
        /// </summary>
        public void MoveUp()
        {
            int oldSelectedIndex = _selectedIndex;
            int fi = GetFirstItemIndexInCurrentPage();
            int li = GetLastItemIndexInCurrentPage();
            _selectedIndex--;
            if (_selectedIndex < fi) _selectedIndex = li;
            if (oldSelectedIndex != _selectedIndex && SelectedItem != null)
            {
                if (PlayBeep) MenuStorage.PlayMenuBeep();
                SelectedItem.OnHighlighted();
            }
        }

        /// <summary>
        /// Moves the cursor to the next page or enter the sub menu
        /// </summary>
        public void MoveRight()
        {
            if (SelectedItem == null) return;
            SelectedItem.OnRightPressed();
            if (PageCount == 1)
            {
                if (SelectedItem.SubMenu != null)
                {
                    SelectedItem.OnActivated();
                    if (PlayBeep) MenuStorage.PlayMenuBeep();
                }
                else if (SelectedItem.FakeSubMenu)
                {
                    SelectedItem.OnActivated();
                    if (PlayBeep) MenuStorage.PlayMenuBeep();
                }
                return;
            }
            if (++_page > PageCount) _page = 1;
            EnsureSelectedIndexInCurrentPage();
            if (PlayBeep) MenuStorage.PlayMenuBeep();
        }

        /// <summary>
        /// Moves the cursor to the previous page
        /// </summary>
        public void MoveLeft()
        {
            if (SelectedItem == null) return;
            SelectedItem.OnLeftPressed();
            if (PageCount == 1) return;
            if (--_page < 1) _page = PageCount;
            EnsureSelectedIndexInCurrentPage();
            if (PlayBeep) MenuStorage.PlayMenuBeep();
        }

        // Ensure the current page is valid
        private void EnsurePage()
        {
            if (_page < 1) Page = 1;
            else if (_page > PageCount) _page = PageCount;
        }

        // Ensure the selected index is in current page
        private void EnsureSelectedIndexInCurrentPage()
        {
            int oldSelectedIndex = _selectedIndex;
            int fi = GetFirstItemIndexInCurrentPage();
            int li = GetLastItemIndexInCurrentPage();
            int ri = GetRelativeSelectedIndexInPage();
            if (_selectedIndex > li || _selectedIndex < fi)
            {
                _selectedIndex = fi + ri;
                if (_selectedIndex > li) _selectedIndex = li;
            }
            if (oldSelectedIndex != _selectedIndex && SelectedItem != null)
            {
                SelectedItem.OnHighlighted();
            }
        }

        // Gets the relative selected index in current page
        private int GetRelativeSelectedIndexInPage()
        {
            return _selectedIndex % _itemPerPage;
        }

        // Gets the index of the first item in the current page
        private int GetFirstItemIndexInCurrentPage()
        {
            return (_page - 1) * _itemPerPage;
        }

        // Gets the index of the last item in the current page
        private int GetLastItemIndexInCurrentPage()
        {
            int si = GetFirstItemIndexInCurrentPage() + _itemPerPage - 1;
            if (si > _items.Count - 1)
            {
                si = _items.Count - 1;
            }

            return si;
        }

        // Gets the page of the selected index
        private int GetPageBySelectedIndex()
        {
            return _selectedIndex / _itemPerPage + 1;
        }

        /// <summary>
        /// Draw this menu
        /// </summary>
        public void Draw()
        {
            // Title
            Utils.DrawRect(Location.X, Location.Y, _width, _titleHeight, TitleBackColor);
            if (!string.IsNullOrEmpty(Utils.ML(Title)))
            {
                Utils.DrawText(Title, Location.X + TitleOffset.X, Location.Y + TitleOffset.Y, TitleAlign, TitleTextColor, TitleScale);
            }

            // Page
            if (PageCount > 1)
            {
                Utils.DrawText(Utils.FormatML(PAGE_FORMAT, _page, PageCount), Location.X + PageTextOffset.X, Location.Y + PageTextOffset.Y, GlobalConst.HAlignment.Left, TitleTextColor, TitleScale);
            }

            // Menu items
            int fi = GetFirstItemIndexInCurrentPage();
            int li = GetLastItemIndexInCurrentPage();
            int index = 0;
            for (int i = fi; i <= li; i++)
            {
                MenuItem mi = _items[i];

                // Text
                if (!string.IsNullOrEmpty(Utils.ML(mi.Text)))
                {
                    if (_selectedIndex == i)
                    {
                        Utils.DrawText(mi.Text, Location.X + mi.TextOffset.X, Location.Y + _titleHeight + _itemSpacing + (_itemHeight + _itemSpacing) * index + mi.TextOffset.Y, mi.Align, mi.SelectedTextColor, mi.SelectedScale);
                    }
                    else
                    {
                        Utils.DrawText(mi.Text, Location.X + mi.TextOffset.X, Location.Y + _titleHeight + _itemSpacing + (_itemHeight + _itemSpacing) * index + mi.TextOffset.Y, mi.Align, mi.TextColor, mi.Scale);
                    }
                }

                // Toggle
                if (mi.IsToggle)
                {
                    if (_selectedIndex == i)
                    {
                        Utils.DrawText(TOGGLE_BRACE, Location.X + ToggleTextOffset.X, Location.Y + _titleHeight + _itemSpacing + (_itemHeight + _itemSpacing) * index + ToggleTextOffset.Y, GlobalConst.HAlignment.Left, mi.SelectedTextColor, mi.SelectedScale);
                        Utils.DrawText((mi.On ? TOGGLE_ON : TOGGLE_OFF), Location.X + ToggleTextOffset.X, Location.Y + _titleHeight + _itemSpacing + (_itemHeight + _itemSpacing) * index + ToggleTextOffset.Y, GlobalConst.HAlignment.Left, (mi.On ? TOGGLE_ON_COLOR_SELECTED : TOGGLE_OFF_COLOR_SELECTED), mi.SelectedScale);
                    }
                    else
                    {
                        Utils.DrawText(TOGGLE_BRACE, Location.X + ToggleTextOffset.X, Location.Y + _titleHeight + _itemSpacing + (_itemHeight + _itemSpacing) * index + ToggleTextOffset.Y, GlobalConst.HAlignment.Left, mi.TextColor, mi.Scale);
                        Utils.DrawText((mi.On ? TOGGLE_ON : TOGGLE_OFF), Location.X + ToggleTextOffset.X, Location.Y + _titleHeight + _itemSpacing + (_itemHeight + _itemSpacing) * index + ToggleTextOffset.Y, GlobalConst.HAlignment.Left, (mi.On ? TOGGLE_ON_COLOR : TOGGLE_OFF_COLOR), mi.Scale);
                    }
                }

                // Sub menu sign
                if (mi.SubMenu != null || mi.FakeSubMenu)
                {
                    if (_selectedIndex == i)
                    {
                        Utils.DrawText(HAS_SUBMENU, Location.X + HasSubmenuSignOffset.X, Location.Y + _titleHeight + _itemSpacing + (_itemHeight + _itemSpacing) * index + HasSubmenuSignOffset.Y, GlobalConst.HAlignment.Left, mi.SelectedTextColor, mi.SelectedScale);
                    }
                    else
                    {
                        Utils.DrawText(HAS_SUBMENU, Location.X + HasSubmenuSignOffset.X, Location.Y + _titleHeight + _itemSpacing + (_itemHeight + _itemSpacing) * index + HasSubmenuSignOffset.Y, GlobalConst.HAlignment.Left, mi.TextColor, mi.Scale);
                    }
                }

                // Left/Right adjustable sign
                if (mi.SubMenu == null && !mi.FakeSubMenu && mi.ShowLeftRightAdjustableSign)
                {
                    if (_selectedIndex == i)
                    {
                        Utils.DrawText(LEFT_RIGHT_ADJUSTABLE, Location.X + LeftRightAdjustableSignOffset.X, Location.Y + _titleHeight + _itemSpacing + (_itemHeight + _itemSpacing) * index + LeftRightAdjustableSignOffset.Y, GlobalConst.HAlignment.Left, mi.SelectedTextColor, mi.SelectedScale);
                    }
                    else
                    {
                        Utils.DrawText(LEFT_RIGHT_ADJUSTABLE, Location.X + LeftRightAdjustableSignOffset.X, Location.Y + _titleHeight + _itemSpacing + (_itemHeight + _itemSpacing) * index + LeftRightAdjustableSignOffset.Y, GlobalConst.HAlignment.Left, mi.TextColor, mi.Scale);
                    }
                }

                // Background
                if (_selectedIndex == i)
                {
                    Utils.DrawRect(Location.X, Location.Y + _titleHeight + _itemSpacing + (_itemHeight + _itemSpacing) * index, _width, _itemHeight, mi.SelectedBackColor);
                }
                else
                {
                    Utils.DrawRect(Location.X, Location.Y + _titleHeight + _itemSpacing + (_itemHeight + _itemSpacing) * index, _width, _itemHeight, mi.BackColor);
                }

                index++;
            }
        }
    }
}
