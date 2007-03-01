﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Daniel Grunwald" email="daniel@danielgrunwald.de"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using ICSharpCode.WpfDesign.Adorners;

namespace ICSharpCode.WpfDesign
{
	/// <summary>
	/// Describes a tool that can handle input on the design surface.
	/// Modelled after the description on http://urbanpotato.net/Default.aspx/document/2300
	/// </summary>
	public interface ITool
	{
		/// <summary>
		/// Gets the cursor used by the tool.
		/// </summary>
		Cursor Cursor { get; }
		
		/// <summary>
		/// Activates the tool, attaching its event handlers to the design panel.
		/// </summary>
		void Activate(IDesignPanel designPanel);
		
		/// <summary>
		/// Deactivates the tool, detaching its event handlers from the design panel.
		/// </summary>
		void Deactivate(IDesignPanel designPanel);
	}
	
	/// <summary>
	/// Service that manages tool selection.
	/// </summary>
	public interface IToolService
	{
		/// <summary>
		/// Gets the 'pointer' tool.
		/// The pointer tool is the default tool for selecting and moving elements.
		/// </summary>
		ITool PointerTool { get; }
		
		/// <summary>
		/// Gets/Sets the currently selected tool.
		/// </summary>
		ITool CurrentTool { get; set; }
	}
	
	/// <summary>
	/// Interface for the design panel. The design panel is the UIElement containing the
	/// designed elements and is responsible for handling mouse and keyboard events.
	/// </summary>
	public interface IDesignPanel : IInputElement
	{
		/// <summary>
		/// Gets the design context used by the DesignPanel.
		/// </summary>
		DesignContext Context { get; }
		
		/// <summary>
		/// Gets/Sets if the design content is visible for hit-testing purposes.
		/// </summary>
		bool IsContentHitTestVisible { get; set; }
		
		/// <summary>
		/// Gets/Sets if the adorner layer is visible for hit-testing purposes.
		/// </summary>
		bool IsAdornerLayerHitTestVisible { get; set; }
		
		/// <summary>
		/// Gets the list of adorners displayed on the design panel.
		/// </summary>
		ICollection<AdornerPanel> Adorners { get; }
		
		/// <summary>
		/// A canvas that is on top of the design surface and all adorners.
		/// Used for temporary drawings that are not attached to any element, e.g. graying out everything
		/// except the target container in drag'n'drop operations.
		/// </summary>
		Canvas MarkerCanvas { get; }
		
		/// <summary>
		/// Performs a hit test on the design surface.
		/// </summary>
		DesignPanelHitTestResult HitTest(MouseEventArgs e, bool testAdorners, bool testDesignSurface);
		
		// The following members were missing in <see cref="IInputElement"/>, but
		// are supported on the DesignPanel:
		
		/// <summary>
		/// Occurs when a mouse button is pressed.
		/// </summary>
		event MouseButtonEventHandler MouseDown;
		
		/// <summary>
		/// Occurs when a mouse button is released.
		/// </summary>
		event MouseButtonEventHandler MouseUp;
	}
}
