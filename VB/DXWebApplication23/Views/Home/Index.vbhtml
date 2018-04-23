@Code 
    ViewBag.Title = "Index"
End Code

<h2>Index</h2>

@Using (Html.BeginForm("Submit", "Home"))
    @Html.Action("SpreadsheetPartial")

    @<input type="submit" value="Save" />
End Using