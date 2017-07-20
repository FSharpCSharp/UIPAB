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
Public Class ProductDS
    Inherits DataSet
    
    Private tableProducts As ProductsDataTable
    
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
            If (Not (ds.Tables("product")) Is Nothing) Then
                Me.Tables.Add(New ProductsDataTable(ds.Tables("product")))
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
    Public ReadOnly Property Products As ProductsDataTable
        Get
            Return Me.tableProducts
        End Get
    End Property
    
    Public Overrides Function Clone() As DataSet
        Dim cln As ProductDS = CType(MyBase.Clone,ProductDS)
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
        If (Not (ds.Tables("product")) Is Nothing) Then
            Me.Tables.Add(New ProductsDataTable(ds.Tables("product")))
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
        Me.tableProducts = CType(Me.Tables("product"),ProductsDataTable)
        If (Not (Me.tableProducts) Is Nothing) Then
            Me.tableProducts.InitVars
        End If
    End Sub
    
    Private Sub InitClass()
        Me.DataSetName = "ProductDS"
        Me.Prefix = ""
        Me.Namespace = "http://tempuri.org/ProductDS.xsd"
        Me.Locale = New System.Globalization.CultureInfo("en-US")
        Me.CaseSensitive = false
        Me.EnforceConstraints = true
        Me.tableProducts = New ProductsDataTable
        Me.Tables.Add(Me.tableProducts)
    End Sub
    
    Private Function ShouldSerializeProducts() As Boolean
        Return false
    End Function
    
    Private Sub SchemaChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)
        If (e.Action = System.ComponentModel.CollectionChangeAction.Remove) Then
            Me.InitVars
        End If
    End Sub
    
    Public Delegate Sub ProductChangeEventHandler(ByVal sender As Object, ByVal e As ProductChangeEvent)
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class ProductsDataTable
        Inherits DataTable
        Implements System.Collections.IEnumerable
        
        Private columnProductId As DataColumn
        
        Private columnCategoryId As DataColumn
        
        Private columnModelNumber As DataColumn
        
        Private columnModelName As DataColumn
        
        Private columnProductImage As DataColumn
        
        Private columnUnitCost As DataColumn
        
        Private columnDescription As DataColumn
        
        Friend Sub New()
            MyBase.New("product")
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
        
        Friend ReadOnly Property ProductIdColumn As DataColumn
            Get
                Return Me.columnProductId
            End Get
        End Property
        
        Friend ReadOnly Property CategoryIdColumn As DataColumn
            Get
                Return Me.columnCategoryId
            End Get
        End Property
        
        Friend ReadOnly Property ModelNumberColumn As DataColumn
            Get
                Return Me.columnModelNumber
            End Get
        End Property
        
        Friend ReadOnly Property ModelNameColumn As DataColumn
            Get
                Return Me.columnModelName
            End Get
        End Property
        
        Friend ReadOnly Property ProductImageColumn As DataColumn
            Get
                Return Me.columnProductImage
            End Get
        End Property
        
        Friend ReadOnly Property UnitCostColumn As DataColumn
            Get
                Return Me.columnUnitCost
            End Get
        End Property
        
        Friend ReadOnly Property DescriptionColumn As DataColumn
            Get
                Return Me.columnDescription
            End Get
        End Property
        
        Public Default ReadOnly Property Item(ByVal index As Integer) As Product
            Get
                Return CType(Me.Rows(index),Product)
            End Get
        End Property
        
        Public Event ProductChanged As ProductChangeEventHandler
        
        Public Event ProductChanging As ProductChangeEventHandler
        
        Public Event ProductDeleted As ProductChangeEventHandler
        
        Public Event ProductDeleting As ProductChangeEventHandler
        
        Public Overloads Sub AddProduct(ByVal row As Product)
            Me.Rows.Add(row)
        End Sub
        
        Public Overloads Function AddProduct(ByVal ProductId As Integer, ByVal CategoryId As Integer, ByVal ModelNumber As String, ByVal ModelName As String, ByVal ProductImage As String, ByVal UnitCost As Decimal, ByVal Description As String) As Product
            Dim rowProduct As Product = CType(Me.NewRow,Product)
            rowProduct.ItemArray = New Object() {ProductId, CategoryId, ModelNumber, ModelName, ProductImage, UnitCost, Description}
            Me.Rows.Add(rowProduct)
            Return rowProduct
        End Function
        
        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        Public Overrides Function Clone() As DataTable
            Dim cln As ProductsDataTable = CType(MyBase.Clone,ProductsDataTable)
            cln.InitVars
            Return cln
        End Function
        
        Protected Overrides Function CreateInstance() As DataTable
            Return New ProductsDataTable
        End Function
        
        Friend Sub InitVars()
            Me.columnProductId = Me.Columns("ProductID")
            Me.columnCategoryId = Me.Columns("CategoryID")
            Me.columnModelNumber = Me.Columns("ModelNumber")
            Me.columnModelName = Me.Columns("ModelName")
            Me.columnProductImage = Me.Columns("ProductImage")
            Me.columnUnitCost = Me.Columns("UnitCost")
            Me.columnDescription = Me.Columns("Description")
        End Sub
        
        Private Sub InitClass()
            Me.columnProductId = New DataColumn("ProductID", GetType(System.Int32), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnProductId)
            Me.columnCategoryId = New DataColumn("CategoryID", GetType(System.Int32), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnCategoryId)
            Me.columnModelNumber = New DataColumn("ModelNumber", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnModelNumber)
            Me.columnModelName = New DataColumn("ModelName", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnModelName)
            Me.columnProductImage = New DataColumn("ProductImage", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnProductImage)
            Me.columnUnitCost = New DataColumn("UnitCost", GetType(System.Decimal), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnUnitCost)
            Me.columnDescription = New DataColumn("Description", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnDescription)
            Me.columnProductId.AllowDBNull = false
            Me.columnCategoryId.AllowDBNull = false
            Me.columnModelNumber.AllowDBNull = false
            Me.columnModelName.AllowDBNull = false
            Me.columnProductImage.AllowDBNull = false
            Me.columnUnitCost.AllowDBNull = false
            Me.columnDescription.AllowDBNull = false
        End Sub
        
        Public Function NewProduct() As Product
            Return CType(Me.NewRow,Product)
        End Function
        
        Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
            Return New Product(builder)
        End Function
        
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(Product)
        End Function
        
        Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.ProductChangedEvent) Is Nothing) Then
                RaiseEvent ProductChanged(Me, New ProductChangeEvent(CType(e.Row,Product), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.ProductChangingEvent) Is Nothing) Then
                RaiseEvent ProductChanging(Me, New ProductChangeEvent(CType(e.Row,Product), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.ProductDeletedEvent) Is Nothing) Then
                RaiseEvent ProductDeleted(Me, New ProductChangeEvent(CType(e.Row,Product), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.ProductDeletingEvent) Is Nothing) Then
                RaiseEvent ProductDeleting(Me, New ProductChangeEvent(CType(e.Row,Product), e.Action))
            End If
        End Sub
        
        Public Sub RemoveProduct(ByVal row As Product)
            Me.Rows.Remove(row)
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class Product
        Inherits DataRow
        
        Private tableProducts As ProductsDataTable
        
        Friend Sub New(ByVal rb As DataRowBuilder)
            MyBase.New(rb)
            Me.tableProducts = CType(Me.Table,ProductsDataTable)
        End Sub
        
        Public Property ProductId As Integer
            Get
                Return CType(Me(Me.tableProducts.ProductIdColumn),Integer)
            End Get
            Set
                Me(Me.tableProducts.ProductIdColumn) = value
            End Set
        End Property
        
        Public Property CategoryId As Integer
            Get
                Return CType(Me(Me.tableProducts.CategoryIdColumn),Integer)
            End Get
            Set
                Me(Me.tableProducts.CategoryIdColumn) = value
            End Set
        End Property
        
        Public Property ModelNumber As String
            Get
                Return CType(Me(Me.tableProducts.ModelNumberColumn),String)
            End Get
            Set
                Me(Me.tableProducts.ModelNumberColumn) = value
            End Set
        End Property
        
        Public Property ModelName As String
            Get
                Return CType(Me(Me.tableProducts.ModelNameColumn),String)
            End Get
            Set
                Me(Me.tableProducts.ModelNameColumn) = value
            End Set
        End Property
        
        Public Property ProductImage As String
            Get
                Return CType(Me(Me.tableProducts.ProductImageColumn),String)
            End Get
            Set
                Me(Me.tableProducts.ProductImageColumn) = value
            End Set
        End Property
        
        Public Property UnitCost As Decimal
            Get
                Return CType(Me(Me.tableProducts.UnitCostColumn),Decimal)
            End Get
            Set
                Me(Me.tableProducts.UnitCostColumn) = value
            End Set
        End Property
        
        Public Property Description As String
            Get
                Return CType(Me(Me.tableProducts.DescriptionColumn),String)
            End Get
            Set
                Me(Me.tableProducts.DescriptionColumn) = value
            End Set
        End Property
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class ProductChangeEvent
        Inherits EventArgs
        
        Private eventRow As Product
        
        Private eventAction As DataRowAction
        
        Public Sub New(ByVal row As Product, ByVal action As DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        Public ReadOnly Property Row As Product
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
