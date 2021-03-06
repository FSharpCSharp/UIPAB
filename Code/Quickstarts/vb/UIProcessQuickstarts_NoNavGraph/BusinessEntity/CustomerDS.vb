﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.1.4322.573
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Runtime.Serialization
Imports System.Xml


<Serializable(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Diagnostics.DebuggerStepThrough(),  _
 System.ComponentModel.ToolboxItem(true)>  _
Public Class CustomerDS
    Inherits DataSet
    
    Private tableCustomers As CustomersDataTable
    
    Public Sub New()
        MyBase.New
        Me.InitClass
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New
        Dim strSchema As String = CType(info.GetValue("XmlSchema", GetType(System.String)),String)
        If (Not (strSchema) Is Nothing) Then
            Dim ds As DataSet = New DataSet
            ds.ReadXmlSchema(New XmlTextReader(New System.IO.StringReader(strSchema)))
            If (Not (ds.Tables("customer")) Is Nothing) Then
                Me.Tables.Add(New CustomersDataTable(ds.Tables("customer")))
            End If
            Me.DataSetName = ds.DataSetName
            Me.Prefix = ds.Prefix
            Me.Namespace = ds.Namespace
            Me.Locale = ds.Locale
            Me.CaseSensitive = ds.CaseSensitive
            Me.EnforceConstraints = ds.EnforceConstraints
            Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
            Me.InitVars
        Else
            Me.InitClass
        End If
        Me.GetSerializationData(info, context)
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    <System.ComponentModel.Browsable(false),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)>  _
    Public ReadOnly Property Customers As CustomersDataTable
        Get
            Return Me.tableCustomers
        End Get
    End Property
    
    Public Overrides Function Clone() As DataSet
        Dim cln As CustomerDS = CType(MyBase.Clone,CustomerDS)
        cln.InitVars
        Return cln
    End Function
    
    Protected Overrides Function ShouldSerializeTables() As Boolean
        Return false
    End Function
    
    Protected Overrides Function ShouldSerializeRelations() As Boolean
        Return false
    End Function
    
    Protected Overrides Sub ReadXmlSerializable(ByVal reader As XmlReader)
        Me.Reset
        Dim ds As DataSet = New DataSet
        ds.ReadXml(reader)
        If (Not (ds.Tables("customer")) Is Nothing) Then
            Me.Tables.Add(New CustomersDataTable(ds.Tables("customer")))
        End If
        Me.DataSetName = ds.DataSetName
        Me.Prefix = ds.Prefix
        Me.Namespace = ds.Namespace
        Me.Locale = ds.Locale
        Me.CaseSensitive = ds.CaseSensitive
        Me.EnforceConstraints = ds.EnforceConstraints
        Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
        Me.InitVars
    End Sub
    
    Protected Overrides Function GetSchemaSerializable() As System.Xml.Schema.XmlSchema
        Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream
        Me.WriteXmlSchema(New XmlTextWriter(stream, Nothing))
        stream.Position = 0
        Return System.Xml.Schema.XmlSchema.Read(New XmlTextReader(stream), Nothing)
    End Function
    
    Friend Sub InitVars()
        Me.tableCustomers = CType(Me.Tables("customer"),CustomersDataTable)
        If (Not (Me.tableCustomers) Is Nothing) Then
            Me.tableCustomers.InitVars
        End If
    End Sub
    
    Private Sub InitClass()
        Me.DataSetName = "CustomerDS"
        Me.Prefix = ""
        Me.Namespace = "http://tempuri.org/CustomerDS.xsd"
        Me.Locale = New System.Globalization.CultureInfo("en-US")
        Me.CaseSensitive = false
        Me.EnforceConstraints = true
        Me.tableCustomers = New CustomersDataTable
        Me.Tables.Add(Me.tableCustomers)
    End Sub
    
    Private Function ShouldSerializeCustomers() As Boolean
        Return false
    End Function
    
    Private Sub SchemaChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)
        If (e.Action = System.ComponentModel.CollectionChangeAction.Remove) Then
            Me.InitVars
        End If
    End Sub
    
    Public Delegate Sub CustomerChangeEventHandler(ByVal sender As Object, ByVal e As CustomerChangeEvent)
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class CustomersDataTable
        Inherits DataTable
        Implements System.Collections.IEnumerable
        
        Private columnCustomerId As DataColumn
        
        Private columnFullName As DataColumn
        
        Private columnEmailAddress As DataColumn
        
        Private columnPassword As DataColumn
        
        Friend Sub New()
            MyBase.New("customer")
            Me.InitClass
        End Sub
        
        Friend Sub New(ByVal table As DataTable)
            MyBase.New(table.TableName)
            If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
                Me.CaseSensitive = table.CaseSensitive
            End If
            If (table.Locale.ToString <> table.DataSet.Locale.ToString) Then
                Me.Locale = table.Locale
            End If
            If (table.Namespace <> table.DataSet.Namespace) Then
                Me.Namespace = table.Namespace
            End If
            Me.Prefix = table.Prefix
            Me.MinimumCapacity = table.MinimumCapacity
            Me.DisplayExpression = table.DisplayExpression
        End Sub
        
        <System.ComponentModel.Browsable(false)>  _
        Public ReadOnly Property Count As Integer
            Get
                Return Me.Rows.Count
            End Get
        End Property
        
        Friend ReadOnly Property CustomerIdColumn As DataColumn
            Get
                Return Me.columnCustomerId
            End Get
        End Property
        
        Friend ReadOnly Property FullNameColumn As DataColumn
            Get
                Return Me.columnFullName
            End Get
        End Property
        
        Friend ReadOnly Property EmailAddressColumn As DataColumn
            Get
                Return Me.columnEmailAddress
            End Get
        End Property
        
        Friend ReadOnly Property PasswordColumn As DataColumn
            Get
                Return Me.columnPassword
            End Get
        End Property
        
        Public Default ReadOnly Property Item(ByVal index As Integer) As Customer
            Get
                Return CType(Me.Rows(index),Customer)
            End Get
        End Property
        
        Public Event CustomerChanged As CustomerChangeEventHandler
        
        Public Event CustomerChanging As CustomerChangeEventHandler
        
        Public Event CustomerDeleted As CustomerChangeEventHandler
        
        Public Event CustomerDeleting As CustomerChangeEventHandler
        
        Public Overloads Sub AddCustomer(ByVal row As Customer)
            Me.Rows.Add(row)
        End Sub
        
        Public Overloads Function AddCustomer(ByVal CustomerId As Integer, ByVal FullName As String, ByVal EmailAddress As String, ByVal Password As String) As Customer
            Dim rowCustomer As Customer = CType(Me.NewRow,Customer)
            rowCustomer.ItemArray = New Object() {CustomerId, FullName, EmailAddress, Password}
            Me.Rows.Add(rowCustomer)
            Return rowCustomer
        End Function
        
        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        Public Overrides Function Clone() As DataTable
            Dim cln As CustomersDataTable = CType(MyBase.Clone,CustomersDataTable)
            cln.InitVars
            Return cln
        End Function
        
        Protected Overrides Function CreateInstance() As DataTable
            Return New CustomersDataTable
        End Function
        
        Friend Sub InitVars()
            Me.columnCustomerId = Me.Columns("CustomerID")
            Me.columnFullName = Me.Columns("FullName")
            Me.columnEmailAddress = Me.Columns("EmailAddress")
            Me.columnPassword = Me.Columns("Password")
        End Sub
        
        Private Sub InitClass()
            Me.columnCustomerId = New DataColumn("CustomerID", GetType(System.Int32), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnCustomerId)
            Me.columnFullName = New DataColumn("FullName", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnFullName)
            Me.columnEmailAddress = New DataColumn("EmailAddress", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnEmailAddress)
            Me.columnPassword = New DataColumn("Password", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnPassword)
            Me.columnCustomerId.AllowDBNull = false
            Me.columnFullName.AllowDBNull = false
            Me.columnEmailAddress.AllowDBNull = false
            Me.columnPassword.AllowDBNull = false
        End Sub
        
        Public Function NewCustomer() As Customer
            Return CType(Me.NewRow,Customer)
        End Function
        
        Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
            Return New Customer(builder)
        End Function
        
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(Customer)
        End Function
        
        Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.CustomerChangedEvent) Is Nothing) Then
                RaiseEvent CustomerChanged(Me, New CustomerChangeEvent(CType(e.Row,Customer), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.CustomerChangingEvent) Is Nothing) Then
                RaiseEvent CustomerChanging(Me, New CustomerChangeEvent(CType(e.Row,Customer), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.CustomerDeletedEvent) Is Nothing) Then
                RaiseEvent CustomerDeleted(Me, New CustomerChangeEvent(CType(e.Row,Customer), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.CustomerDeletingEvent) Is Nothing) Then
                RaiseEvent CustomerDeleting(Me, New CustomerChangeEvent(CType(e.Row,Customer), e.Action))
            End If
        End Sub
        
        Public Sub RemoveCustomer(ByVal row As Customer)
            Me.Rows.Remove(row)
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class Customer
        Inherits DataRow
        
        Private tableCustomers As CustomersDataTable
        
        Friend Sub New(ByVal rb As DataRowBuilder)
            MyBase.New(rb)
            Me.tableCustomers = CType(Me.Table,CustomersDataTable)
        End Sub
        
        Public Property CustomerId As Integer
            Get
                Return CType(Me(Me.tableCustomers.CustomerIdColumn),Integer)
            End Get
            Set
                Me(Me.tableCustomers.CustomerIdColumn) = value
            End Set
        End Property
        
        Public Property FullName As String
            Get
                Return CType(Me(Me.tableCustomers.FullNameColumn),String)
            End Get
            Set
                Me(Me.tableCustomers.FullNameColumn) = value
            End Set
        End Property
        
        Public Property EmailAddress As String
            Get
                Return CType(Me(Me.tableCustomers.EmailAddressColumn),String)
            End Get
            Set
                Me(Me.tableCustomers.EmailAddressColumn) = value
            End Set
        End Property
        
        Public Property Password As String
            Get
                Return CType(Me(Me.tableCustomers.PasswordColumn),String)
            End Get
            Set
                Me(Me.tableCustomers.PasswordColumn) = value
            End Set
        End Property
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class CustomerChangeEvent
        Inherits EventArgs
        
        Private eventRow As Customer
        
        Private eventAction As DataRowAction
        
        Public Sub New(ByVal row As Customer, ByVal action As DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        Public ReadOnly Property Row As Customer
            Get
                Return Me.eventRow
            End Get
        End Property
        
        Public ReadOnly Property Action As DataRowAction
            Get
                Return Me.eventAction
            End Get
        End Property
    End Class
End Class
