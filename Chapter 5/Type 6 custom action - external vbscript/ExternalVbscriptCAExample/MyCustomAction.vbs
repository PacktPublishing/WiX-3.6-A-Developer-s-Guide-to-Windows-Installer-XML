
function myFunction()
  If Session.Property("MY_PROPERTY") = "1" Then
    msgbox "Property is 1. Returning success!"
    myFunction = 1
    Exit Function
  End If

  msgbox "Property not 1. Returning failure."
  myFunction = 3
  Exit Function
End function