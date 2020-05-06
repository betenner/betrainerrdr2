///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

using System.Drawing;

namespace BETrainerRdr2.Menu
{
    /// <summary>
    /// Menu item
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// On pre-activated event handler
        /// </summary>
        public event MenuItemEventHandler PreActivated = null;

        /// <summary>
        /// On activated event handler
        /// </summary>
        public event MenuItemEventHandler Activated = null;

        /// <summary>
        /// On pressed left event handler
        /// </summary>
        public event MenuItemEventHandler LeftPressed = null;

        /// <summary>
        /// On pressed right event handler
        /// </summary>
        public event MenuItemEventHandler RightPressed = null;

        /// <summary>
        /// On highlighted event handler
        /// </summary>
        public event MenuItemEventHandler Highlighted = null;

        /// <summary>
        /// Parent menu
        /// </summary>
        public Menu Parent = null;

        /// <summary>
        /// Text
        /// </summary>
        public MLString Text = null;

        /// <summary>
        /// Is toggle able item
        /// </summary>
        public bool IsToggle = false;

        /// <summary>
        /// Is ON now
        /// </summary>
        public bool On = false;

        /// <summary>
        /// Index in parent, for reference only
        /// </summary>
        public int Index = -1;

        /// <summary>
        /// Text color
        /// </summary>
        public Color TextColor = Color.White;

        /// <summary>
        /// Back color
        /// </summary>
        public Color BackColor = Color.FromArgb(96, Color.Black);

        /// <summary>
        /// Shadow offset
        /// </summary>
        public Point ShadowOffset = new Point();

        /// <summary>
        /// Shadow color
        /// </summary>
        public Color ShadowColor = Color.Black;

        /// <summary>
        /// Selected text color
        /// </summary>
        public Color SelectedTextColor = Color.Black;

        /// <summary>
        /// Selected back color
        /// </summary>
        public Color SelectedBackColor = Color.FromArgb(192, 218, 242, 216);

        /// <summary>
        /// Prevents from entering the sub menu once
        /// </summary>
        public bool PreventsEnteringSubMenuOnce = false;

        // Text x scale
        private float _scale = 0.35f;

        /// <summary>
        /// Bind data
        /// </summary>
        public object Data = null;

        /// <summary>
        /// Text scale
        /// </summary>
        public float Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
                if (_scale < 0f) _scale = 0f;
            }
        }

        // Selected text cale
        private float _selectedScale = 0.35f;

        /// <summary>
        /// Selected text scale
        /// </summary>
        public float SelectedScale
        {
            get
            {
                return _selectedScale;
            }
            set
            {
                _selectedScale = value;
                if (_selectedScale < 0f) _selectedScale = 0f;
            }
        }

        /// <summary>
        /// Font
        /// </summary>
        public RDR2.UI.Font Font = RDR2.UI.Font.ChaletLondon;

        /// <summary>
        /// GlobalConst.HAlignment
        /// </summary>
        public GlobalConst.HAlignment Align = GlobalConst.HAlignment.Left;

        /// <summary>
        /// Text offset
        /// </summary>
        public Point TextOffset = new Point(10, 5);

        /// <summary>
        /// Selected text offset
        /// </summary>
        public Point SelectedTextOffset = new Point(10, 5);

        /// <summary>
        /// Sub menu
        /// </summary>
        public Menu SubMenu = null;

        /// <summary>
        /// Show fake sub menu sign
        /// </summary>
        public bool FakeSubMenu = false;

        /// <summary>
        /// Show left/right adjustable sign
        /// </summary>
        public bool ShowLeftRightAdjustableSign = false;

        /// <summary>
        /// Pre-activate this menu item
        /// </summary>
        public void OnPreActivated()
        {
            if (PreActivated != null) PreActivated(this);
        }

        /// <summary>
        /// Activate this menu item
        /// </summary>
        public void OnActivated()
        {
            OnPreActivated();
            if (IsToggle) On = !On;
            if (SubMenu != null)
            {
                if (PreventsEnteringSubMenuOnce)
                {
                    PreventsEnteringSubMenuOnce = false;
                }
                else
                {
                    MenuStorage.EnterMenu(SubMenu);
                }
            }
            if (Activated != null) Activated(this);
        }

        /// <summary>
        /// Pressed left
        /// </summary>
        public void OnLeftPressed()
        {
            if (LeftPressed != null) LeftPressed(this);
        }

        /// <summary>
        /// Pressed right
        /// </summary>
        public void OnRightPressed()
        {
            if (RightPressed != null) RightPressed(this);
        }

        /// <summary>
        /// Highlighted
        /// </summary>
        public void OnHighlighted()
        {
            if (Highlighted != null) Highlighted(this);
        }
    }
}
