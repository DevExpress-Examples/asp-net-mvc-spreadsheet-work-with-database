@Using (Html.BeginForm("Submit", "Home"))
    @<input type="submit" value="Save Document" />
    @Html.Action("SpreadsheetPartial")
End Using