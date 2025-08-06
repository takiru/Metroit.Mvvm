# Metroit.Mvvm

|Module                |NuGet | Target Framework |
|----------------------|------|------------------|
|Metroit.Mvvm               |[![NuGet](https://img.shields.io/badge/nuget-v0.0.3-blue.svg)](https://www.nuget.org/packages/Metroit.Mvvm/) | `net6.0` `net8.0` `net9.0` `netstandard2.0` `netstandard2.1` |
|Metroit.Mvvm.WinForms          |[![NuGet](https://img.shields.io/badge/nuget-v0.0.3-blue.svg)](https://www.nuget.org/packages/Metroit.Mvvm.WinForms/) | `net8.0-windows` `net462` |
|Metroit.CommunityToolkit.Mvvm |[![NuGet](https://img.shields.io/badge/nuget-v0.0.3-blue.svg)](https://www.nuget.org/packages/Metroit.CommunityToolkit.Mvvm/) | `net8.0` `netstandard2.0` `netstandard2.1` |
|Metroit.Windows.Forms.Mvvm|[![NuGet](https://img.shields.io/badge/nuget-v0.0.3-blue.svg)](https://www.nuget.org/packages/Metroit.Windows.Forms.Mvvm/) | `net6.0-windows` `net8.0-windows` `net462` |

## Metroit.Mvvm Description
- DialogResultType
- MessageBoxDefaultButtonType
- Interfaces.IDialogRequest
- Interfaces.IDialogResponse
- Interfaces.IDialogService
- Interfaces.IMessageService
- ViewModels.IViewModel  
    It has a ViewService property.
- ViewModels.ViewModelBase  
    Constructor with ViewService as an argument.
- ViewModels.ViewService  
    Constructor with IDialogService and IMessageService<DialogResultType> as arguments.

## Metroit.Mvvm.WinForms Description
It helps in binding the properties of a class to the DataBinding of a control.
  - Extensions.ButtonExtensions
  - Extensions.CheckBoxExtensions
  - Extensions.ComboBoxExtensions
  - Extensions.ControlExtensions
  - Extensions.DateTimePickerExtensions
  - Extensions.LabelExtensions
  - Extensions.ListControlExtensions
  - Extensions.PropertyBindExtensions
  - Extensions.RadioButtonExtensions

    ```
    Extensions.PropertyBindExtensions allows you to create Extensions that are not provided.
    ```

- Views.ActiveFormTracker  
    It always keeps track of the active form object, regardless of the debugging environment.  
    Useful for things like the OwnerFormProvider property of IMessageService<T>.
- Views.MessageService  
    Provides information, confirmation, warning, and error messages.
- Views.ViewBase  
    You can generate a ViewModel that is recognized by the View.  
    It has a constructor that can recognize the ViewModel through DI.  
    You can obtain the recognized ViewModel.

## Metroit.CommunityToolkit.Mvvm Description
Provides convenient functions using CommunityToolkit.Mvvm.

Provides an object whose value can be tracked for changes.
  - TrackingObservableObject
  - TrackingObservableRecipient
  - TrackingObservableValidator
  - StatefulTrackingObservableObject
  - StatefulTrackingObservableRecipient
  - StatefulTrackingObservableValidator

This is a ViewModel that implements Metroit.Mvvm.ViewModels.IViewModel.
  - TrackingObservableObjectViewModelBase
  - TrackingObservableRecipientViewModelBase
  - TrackingObservableValidatorViewModelBase
  - StatefulTrackingObservableObjectViewModelBase
  - StatefulTrackingObservableRecipientViewModelBase
  - StatefulTrackingObservableValidatorViewModelBase

## Metroit.Windows.Forms.Mvvm Description
It helps to bind properties of Metroit.Windows.Forms specific classes to DataBinding of controls.
  - Extensions.AutoCompleteBoxExtensions
  - Extensions.PropertyBindExtensions

    ```
    Extensions.PropertyBindExtensions is for Extensions.AutoCompleteBoxExtensions.There is no need to actively use it.
    ```

- Views.MetViewBase  
    You can generate a ViewModel that is recognized by the View.  
    It has a constructor that can recognize the ViewModel through DI.  
    You can obtain the recognized ViewModel.
