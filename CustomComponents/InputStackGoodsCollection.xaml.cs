namespace PogranPunktApp.CustomComponents;
using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

public partial class InputStackGoodsCollection : ContentView
{
	public InputStackGoodsCollection()
	{
		InitializeComponent();
	}

    private void AddItem(object sender, EventArgs e)
    {
        var insertItem = new InsertItemLayout();
        insertItem.Completed += OnItemCompleted;
        ItemsStack.Children.Add(insertItem);
        AddButton.IsEnabled = false; // Disable add button while editing
    }

    private void OnItemCompleted(object sender, EventArgs e)
    {
        var insertItem = (InsertItemLayout)sender;
        if (insertItem.IsValid)
        {
            string itemData = insertItem.GetItemData();
            // Do something with the item data (e.g., display, store)
            ItemsStack.Children.Remove(insertItem);
        }
        AddButton.IsEnabled = true; // Re-enable add button
    }
}

