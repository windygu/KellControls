using System;
using System.ComponentModel;
using System.Drawing;

using KellControls.KellTable.Editors;
using KellControls.KellTable.Events;
using KellControls.KellTable.Models.Design;
using KellControls.KellTable.Renderers;
using KellControls.KellTable.Sorting;


namespace KellControls.KellTable.Models
{
	/// <summary>
	/// Represents a Column whose Cells are displayed as a CheckBox
	/// </summary>
	[DesignTimeVisible(false),
	ToolboxItem(false)]
	public class CheckBoxColumn : Column
	{
		#region Class Data

		/// <summary>
		/// The size of the checkbox
		/// </summary>
		private Size checkSize;

		/// <summary>
		/// Specifies whether any text contained in the Cell should be drawn
		/// </summary>
		private bool drawText;

		/// <summary>
		/// The style of the checkboxes
		/// </summary>
		private CheckBoxColumnStyle checkStyle;

		#endregion
		

		#region Constructor
		
		/// <summary>
		/// Creates a new CheckBoxColumn with default values
		/// </summary>
        public CheckBoxColumn(Type dataType)
            : base(dataType)
		{
			this.Init();
		}


		/// <summary>
		/// Creates a new CheckBoxColumn with the specified header text
		/// </summary>
		/// <param name="text">The text displayed in the column's header</param>
        public CheckBoxColumn(string text, Type dataType)
            : base(text, dataType)
		{
			this.Init();
		}


		/// <summary>
		/// Creates a new CheckBoxColumn with the specified header text and width
		/// </summary>
		/// <param name="text">The text displayed in the column's header</param>
		/// <param name="width">The column's width</param>
        public CheckBoxColumn(string text, int width, Type dataType)
            : base(text, width, dataType)
		{
			this.Init();
		}


		/// <summary>
		/// Creates a new CheckBoxColumn with the specified header text, width and visibility
		/// </summary>
		/// <param name="text">The text displayed in the column's header</param>
		/// <param name="width">The column's width</param>
		/// <param name="visible">Specifies whether the column is visible</param>
        public CheckBoxColumn(string text, int width, bool visible, Type dataType)
            : base(text, width, visible, dataType)
		{
			this.Init();
		}


		/// <summary>
		/// Creates a new CheckBoxColumn with the specified header text and image
		/// </summary>
		/// <param name="text">The text displayed in the column's header</param>
		/// <param name="image">The image displayed on the column's header</param>
        public CheckBoxColumn(string text, Image image, Type dataType)
            : base(text, image, dataType)
		{
			this.Init();
		}


		/// <summary>
		/// Creates a new CheckBoxColumn with the specified header text, image and width
		/// </summary>
		/// <param name="text">The text displayed in the column's header</param>
		/// <param name="image">The image displayed on the column's header</param>
		/// <param name="width">The column's width</param>
        public CheckBoxColumn(string text, Image image, int width, Type dataType)
            : base(text, image, width, dataType)
		{
			this.Init();
		}


		/// <summary>
		/// Creates a new CheckBoxColumn with the specified header text, image, width and visibility
		/// </summary>
		/// <param name="text">The text displayed in the column's header</param>
		/// <param name="image">The image displayed on the column's header</param>
		/// <param name="width">The column's width</param>
		/// <param name="visible">Specifies whether the column is visible</param>
        public CheckBoxColumn(string text, Image image, int width, bool visible, Type dataType)
            : base(text, image, width, visible, dataType)
		{
			this.Init();
		}


		/// <summary>
		/// Initializes the CheckBoxColumn with default values
		/// </summary>
		private void Init()
		{
			this.checkSize = new Size(13, 13);
			this.drawText = true;
			this.checkStyle = CheckBoxColumnStyle.CheckBox;
		}

		#endregion


		#region Methods

		/// <summary>
		/// Gets a string that specifies the name of the Column's default CellRenderer
		/// </summary>
		/// <returns>A string that specifies the name of the Column's default 
		/// CellRenderer</returns>
		public override string GetDefaultRendererName()
		{
			return "CHECKBOX";
		}


		/// <summary>
		/// Gets the Column's default CellRenderer
		/// </summary>
		/// <returns>The Column's default CellRenderer</returns>
		public override ICellRenderer CreateDefaultRenderer()
		{
			return new CheckBoxCellRenderer();
		}


		/// <summary>
		/// Gets a string that specifies the name of the Column's default CellEditor
		/// </summary>
		/// <returns>A string that specifies the name of the Column's default 
		/// CellEditor</returns>
		public override string GetDefaultEditorName()
		{
			return null;
		}


		/// <summary>
		/// Gets the Column's default CellEditor
		/// </summary>
		/// <returns>The Column's default CellEditor</returns>
		public override ICellEditor CreateDefaultEditor()
		{
			return null;
		}

		#endregion
		
		
		#region Properties

		/// <summary>
		/// Gets or sets the size of the checkboxes
		/// </summary>
		[Category("Appearance"),
		Description("Specifies the size of the checkboxes")]
		public Size CheckSize
		{
			get
			{
				return this.checkSize;
			}

			set
			{
				if (value.Width < 0 || value.Height < 0)
				{
					value = new Size(13, 13);
				}
				
				if (this.checkSize != value)
				{
					this.checkSize = value;

					this.OnPropertyChanged(new ColumnEventArgs(this, ColumnEventType.RendererChanged, null));
				}
			}
		}


		/// <summary>
		/// Specifies whether the CheckSize property should be serialized at 
		/// design time
		/// </summary>
		/// <returns>true if the CheckSize property should be serialized, 
		/// false otherwise</returns>
		private bool ShouldSerializeCheckSize()
		{
			return (this.checkSize.Width != 13 || this.checkSize.Height != 13);
		}

		
		/// <summary>
		/// Gets or sets whether any text contained in the Cell should be drawn
		/// </summary>
		[Category("Appearance"),
		DefaultValue(true),
		Description("Specifies whether any text contained in the Cell should be drawn")]
		public bool DrawText
		{
			get
			{
				return this.drawText;
			}

			set
			{
				if (this.drawText != value)
				{
					this.drawText = value;

					this.OnPropertyChanged(new ColumnEventArgs(this, ColumnEventType.RendererChanged, null));
				}
			}
		}

		
		/// <summary>
		/// Gets or sets whether any text contained in the Cell should be drawn
		/// </summary>
		[Category("Appearance"),
		DefaultValue(CheckBoxColumnStyle.CheckBox),
		Description("Specifies the style of the checkboxes")]
		public CheckBoxColumnStyle CheckStyle
		{
			get
			{
				return this.checkStyle;
			}

			set
			{
				if (!Enum.IsDefined(typeof(CheckBoxColumnStyle), value)) 
				{
					throw new InvalidEnumArgumentException("value", (int) value, typeof(CheckBoxColumnStyle));
				}
					
				if (this.checkStyle != value)
				{
					this.checkStyle = value;

					this.OnPropertyChanged(new ColumnEventArgs(this, ColumnEventType.RendererChanged, null));
				}
			}
		}


		/// <summary>
		/// Gets the Type of the Comparer used to compare the Column's Cells when 
		/// the Column is sorting
		/// </summary>
		public override Type DefaultComparerType
		{
			get
			{
				return typeof(CheckBoxComparer);
			}
		}

		#endregion
	}
}
