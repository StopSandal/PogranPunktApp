namespace PogranPunktApp.CustomComponents;
using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using PogranPunktApp.SQL.Tables.FunctionAdapter;

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
        CompletedEventArgs ComletedE = (CompletedEventArgs)e;
        if (ComletedE.IsCanceled)
        {
            ItemsStack.Children.Remove(insertItem);
            if (ComletedE.IsCompleted)
                return;
        }
        if (insertItem.IsValid && ComletedE.IsCompleted)
        {
           
            // Do something with the item data (e.g., display, store)
           
        }
        AddButton.IsEnabled = true; // Re-enable add button
    }
    public bool IsItemsReadyToInsert()
    {
        foreach (var item in ItemsStack.Children)
        {
            if (item is InsertItemLayout)
                if( (item as  InsertItemLayout).GetItemData() is null)
                {
                    return false;
                }
        }
        return true;
    }
    public IEnumerable<“Ó‚‡˚Insert> GetAll“Ó‚‡˚()
    {
        List <“Ó‚‡˚Insert> list = new List<“Ó‚‡˚Insert>();
        foreach (var item in ItemsStack.Children)
        {
            if (item is InsertItemLayout)
                list.Add((item as InsertItemLayout).GetItemData());
        }
        return list;

    }
}

