namespace orderManagement;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        customerBindingSource = new System.Windows.Forms.BindingSource(components);
        itemBindingSource = new System.Windows.Forms.BindingSource(components);
        orderBindingSource = new System.Windows.Forms.BindingSource(components);
        tabControlMain = new System.Windows.Forms.TabControl();
        tabPageCustomers = new System.Windows.Forms.TabPage();
        buttonCustomerClearFilter = new System.Windows.Forms.Button();
        buttonCustomerApplyFilter = new System.Windows.Forms.Button();
        textBoxCustomerAddress = new System.Windows.Forms.TextBox();
        labelCustomerAddress = new System.Windows.Forms.Label();
        textBoxCustomerPhone = new System.Windows.Forms.TextBox();
        labelCustomerPhone = new System.Windows.Forms.Label();
        textBoxCustomerContact = new System.Windows.Forms.TextBox();
        labelCustomerContact = new System.Windows.Forms.Label();
        textBoxCustomerName = new System.Windows.Forms.TextBox();
        labelCustomerName = new System.Windows.Forms.Label();
        buttonCustomerDelete = new System.Windows.Forms.Button();
        buttonCustomerEdit = new System.Windows.Forms.Button();
        buttonCustomerAdd = new System.Windows.Forms.Button();
        dataGridViewCustomers = new System.Windows.Forms.DataGridView();
        customerIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        customerNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        customerContactColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        customerPhoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        customerAddressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        tabPageItems = new System.Windows.Forms.TabPage();
        comboBoxItemDelivery = new System.Windows.Forms.ComboBox();
        labelItemDelivery = new System.Windows.Forms.Label();
        numericItemPriceMax = new System.Windows.Forms.NumericUpDown();
        numericItemPriceMin = new System.Windows.Forms.NumericUpDown();
        labelItemPriceTo = new System.Windows.Forms.Label();
        labelItemPriceFrom = new System.Windows.Forms.Label();
        textBoxItemDescription = new System.Windows.Forms.TextBox();
        labelItemDescription = new System.Windows.Forms.Label();
        buttonItemClearFilter = new System.Windows.Forms.Button();
        buttonItemApplyFilter = new System.Windows.Forms.Button();
        buttonItemDelete = new System.Windows.Forms.Button();
        buttonItemEdit = new System.Windows.Forms.Button();
        buttonItemAdd = new System.Windows.Forms.Button();
        dataGridViewItems = new System.Windows.Forms.DataGridView();
        itemIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        itemDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        itemPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        itemDeliveryColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        tabPageOrders = new System.Windows.Forms.TabPage();
        buttonOrderImportExcel = new System.Windows.Forms.Button();
        buttonOrderExportExcel = new System.Windows.Forms.Button();
        buttonOrderGenerateReport = new System.Windows.Forms.Button();
        buttonOrderGenerateInvoice = new System.Windows.Forms.Button();
        buttonOrderClearFilter = new System.Windows.Forms.Button();
        buttonOrderApplyFilter = new System.Windows.Forms.Button();
        numericOrderQuantityMax = new System.Windows.Forms.NumericUpDown();
        numericOrderQuantityMin = new System.Windows.Forms.NumericUpDown();
        labelOrderQuantityTo = new System.Windows.Forms.Label();
        labelOrderQuantityFrom = new System.Windows.Forms.Label();
        dateTimePickerOrderDate = new System.Windows.Forms.DateTimePicker();
        labelOrderDate = new System.Windows.Forms.Label();
        comboBoxOrderItem = new System.Windows.Forms.ComboBox();
        labelOrderItem = new System.Windows.Forms.Label();
        comboBoxOrderCustomer = new System.Windows.Forms.ComboBox();
        labelOrderCustomer = new System.Windows.Forms.Label();
        buttonOrderDelete = new System.Windows.Forms.Button();
        buttonOrderEdit = new System.Windows.Forms.Button();
        buttonOrderAdd = new System.Windows.Forms.Button();
        dataGridViewOrders = new System.Windows.Forms.DataGridView();
        orderIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        orderCustomerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        orderItemColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        orderQuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        orderDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        orderTotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)customerBindingSource).BeginInit();
        ((System.ComponentModel.ISupportInitialize)itemBindingSource).BeginInit();
        ((System.ComponentModel.ISupportInitialize)orderBindingSource).BeginInit();
        tabControlMain.SuspendLayout();
        tabPageCustomers.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).BeginInit();
        tabPageItems.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numericItemPriceMax).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericItemPriceMin).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dataGridViewItems).BeginInit();
        tabPageOrders.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numericOrderQuantityMax).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericOrderQuantityMin).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
        SuspendLayout();
        // 
        // customerBindingSource
        // 
        customerBindingSource.DataSource = typeof(orderManagement.Models.Customer);
        // 
        // itemBindingSource
        // 
        itemBindingSource.DataSource = typeof(orderManagement.Models.Item);
        // 
        // orderBindingSource
        // 
        orderBindingSource.DataSource = typeof(orderManagement.Models.Order);
        // 
        // tabControlMain
        // 
        tabControlMain.Controls.Add(tabPageCustomers);
        tabControlMain.Controls.Add(tabPageItems);
        tabControlMain.Controls.Add(tabPageOrders);
        tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
        tabControlMain.Location = new System.Drawing.Point(0, 0);
        tabControlMain.Name = "tabControlMain";
        tabControlMain.SelectedIndex = 0;
        tabControlMain.Size = new System.Drawing.Size(1234, 681);
        tabControlMain.TabIndex = 0;
        // 
        // tabPageCustomers
        // 
        tabPageCustomers.Controls.Add(buttonCustomerClearFilter);
        tabPageCustomers.Controls.Add(buttonCustomerApplyFilter);
        tabPageCustomers.Controls.Add(textBoxCustomerAddress);
        tabPageCustomers.Controls.Add(labelCustomerAddress);
        tabPageCustomers.Controls.Add(textBoxCustomerPhone);
        tabPageCustomers.Controls.Add(labelCustomerPhone);
        tabPageCustomers.Controls.Add(textBoxCustomerContact);
        tabPageCustomers.Controls.Add(labelCustomerContact);
        tabPageCustomers.Controls.Add(textBoxCustomerName);
        tabPageCustomers.Controls.Add(labelCustomerName);
        tabPageCustomers.Controls.Add(buttonCustomerDelete);
        tabPageCustomers.Controls.Add(buttonCustomerEdit);
        tabPageCustomers.Controls.Add(buttonCustomerAdd);
        tabPageCustomers.Controls.Add(dataGridViewCustomers);
        tabPageCustomers.Location = new System.Drawing.Point(4, 29);
        tabPageCustomers.Name = "tabPageCustomers";
        tabPageCustomers.Padding = new System.Windows.Forms.Padding(3);
        tabPageCustomers.Size = new System.Drawing.Size(1226, 648);
        tabPageCustomers.TabIndex = 0;
        tabPageCustomers.Text = "Клиенты";
        tabPageCustomers.UseVisualStyleBackColor = true;
        // 
        // buttonCustomerClearFilter
        // 
        buttonCustomerClearFilter.Location = new System.Drawing.Point(1019, 318);
        buttonCustomerClearFilter.Name = "buttonCustomerClearFilter";
        buttonCustomerClearFilter.Size = new System.Drawing.Size(200, 32);
        buttonCustomerClearFilter.TabIndex = 13;
        buttonCustomerClearFilter.Text = "Очистить фильтр";
        buttonCustomerClearFilter.UseVisualStyleBackColor = true;
        buttonCustomerClearFilter.Click += buttonCustomerClearFilter_Click;
        // 
        // buttonCustomerApplyFilter
        // 
        buttonCustomerApplyFilter.Location = new System.Drawing.Point(815, 318);
        buttonCustomerApplyFilter.Name = "buttonCustomerApplyFilter";
        buttonCustomerApplyFilter.Size = new System.Drawing.Size(198, 32);
        buttonCustomerApplyFilter.TabIndex = 12;
        buttonCustomerApplyFilter.Text = "Применить фильтр";
        buttonCustomerApplyFilter.UseVisualStyleBackColor = true;
        buttonCustomerApplyFilter.Click += buttonCustomerApplyFilter_Click;
        // 
        // textBoxCustomerAddress
        // 
        textBoxCustomerAddress.Location = new System.Drawing.Point(410, 368);
        textBoxCustomerAddress.Multiline = true;
        textBoxCustomerAddress.Name = "textBoxCustomerAddress";
        textBoxCustomerAddress.Size = new System.Drawing.Size(366, 72);
        textBoxCustomerAddress.TabIndex = 11;
        // 
        // labelCustomerAddress
        // 
        labelCustomerAddress.AutoSize = true;
        labelCustomerAddress.Location = new System.Drawing.Point(410, 345);
        labelCustomerAddress.Name = "labelCustomerAddress";
        labelCustomerAddress.Size = new System.Drawing.Size(50, 20);
        labelCustomerAddress.TabIndex = 10;
        labelCustomerAddress.Text = "Адрес";
        // 
        // textBoxCustomerPhone
        // 
        textBoxCustomerPhone.Location = new System.Drawing.Point(410, 312);
        textBoxCustomerPhone.Name = "textBoxCustomerPhone";
        textBoxCustomerPhone.Size = new System.Drawing.Size(366, 27);
        textBoxCustomerPhone.TabIndex = 9;
        // 
        // labelCustomerPhone
        // 
        labelCustomerPhone.AutoSize = true;
        labelCustomerPhone.Location = new System.Drawing.Point(410, 289);
        labelCustomerPhone.Name = "labelCustomerPhone";
        labelCustomerPhone.Size = new System.Drawing.Size(62, 20);
        labelCustomerPhone.TabIndex = 8;
        labelCustomerPhone.Text = "Телефон";
        // 
        // textBoxCustomerContact
        // 
        textBoxCustomerContact.Location = new System.Drawing.Point(18, 368);
        textBoxCustomerContact.Name = "textBoxCustomerContact";
        textBoxCustomerContact.Size = new System.Drawing.Size(366, 27);
        textBoxCustomerContact.TabIndex = 7;
        // 
        // labelCustomerContact
        // 
        labelCustomerContact.AutoSize = true;
        labelCustomerContact.Location = new System.Drawing.Point(18, 345);
        labelCustomerContact.Name = "labelCustomerContact";
        labelCustomerContact.Size = new System.Drawing.Size(114, 20);
        labelCustomerContact.TabIndex = 6;
        labelCustomerContact.Text = "Контактное лицо";
        // 
        // textBoxCustomerName
        // 
        textBoxCustomerName.Location = new System.Drawing.Point(18, 312);
        textBoxCustomerName.Name = "textBoxCustomerName";
        textBoxCustomerName.Size = new System.Drawing.Size(366, 27);
        textBoxCustomerName.TabIndex = 5;
        // 
        // labelCustomerName
        // 
        labelCustomerName.AutoSize = true;
        labelCustomerName.Location = new System.Drawing.Point(18, 289);
        labelCustomerName.Name = "labelCustomerName";
        labelCustomerName.Size = new System.Drawing.Size(73, 20);
        labelCustomerName.TabIndex = 4;
        labelCustomerName.Text = "Название";
        // 
        // buttonCustomerDelete
        // 
        buttonCustomerDelete.Location = new System.Drawing.Point(430, 247);
        buttonCustomerDelete.Name = "buttonCustomerDelete";
        buttonCustomerDelete.Size = new System.Drawing.Size(200, 29);
        buttonCustomerDelete.TabIndex = 3;
        buttonCustomerDelete.Text = "Удалить";
        buttonCustomerDelete.UseVisualStyleBackColor = true;
        buttonCustomerDelete.Click += buttonCustomerDelete_Click;
        // 
        // buttonCustomerEdit
        // 
        buttonCustomerEdit.Location = new System.Drawing.Point(224, 247);
        buttonCustomerEdit.Name = "buttonCustomerEdit";
        buttonCustomerEdit.Size = new System.Drawing.Size(200, 29);
        buttonCustomerEdit.TabIndex = 2;
        buttonCustomerEdit.Text = "Редактировать";
        buttonCustomerEdit.UseVisualStyleBackColor = true;
        buttonCustomerEdit.Click += buttonCustomerEdit_Click;
        // 
        // buttonCustomerAdd
        // 
        buttonCustomerAdd.Location = new System.Drawing.Point(18, 247);
        buttonCustomerAdd.Name = "buttonCustomerAdd";
        buttonCustomerAdd.Size = new System.Drawing.Size(200, 29);
        buttonCustomerAdd.TabIndex = 1;
        buttonCustomerAdd.Text = "Добавить";
        buttonCustomerAdd.UseVisualStyleBackColor = true;
        buttonCustomerAdd.Click += buttonCustomerAdd_Click;
        // 
        // dataGridViewCustomers
        // 
        dataGridViewCustomers.AllowUserToAddRows = false;
        dataGridViewCustomers.AllowUserToDeleteRows = false;
        dataGridViewCustomers.AllowUserToOrderColumns = true;
        dataGridViewCustomers.AutoGenerateColumns = false;
        dataGridViewCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dataGridViewCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { customerIdColumn, customerNameColumn, customerContactColumn, customerPhoneColumn, customerAddressColumn });
        dataGridViewCustomers.DataSource = customerBindingSource;
        dataGridViewCustomers.Location = new System.Drawing.Point(6, 6);
        dataGridViewCustomers.MultiSelect = false;
        dataGridViewCustomers.Name = "dataGridViewCustomers";
        dataGridViewCustomers.ReadOnly = true;
        dataGridViewCustomers.RowHeadersWidth = 51;
        dataGridViewCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dataGridViewCustomers.Size = new System.Drawing.Size(1214, 235);
        dataGridViewCustomers.TabIndex = 0;
        // 
        // customerIdColumn
        // 
        customerIdColumn.DataPropertyName = "CustomerId";
        customerIdColumn.HeaderText = "ID";
        customerIdColumn.MinimumWidth = 6;
        customerIdColumn.Name = "customerIdColumn";
        customerIdColumn.ReadOnly = true;
        customerIdColumn.Visible = false;
        // 
        // customerNameColumn
        // 
        customerNameColumn.DataPropertyName = "Name";
        customerNameColumn.HeaderText = "Название";
        customerNameColumn.MinimumWidth = 6;
        customerNameColumn.Name = "customerNameColumn";
        customerNameColumn.ReadOnly = true;
        // 
        // customerContactColumn
        // 
        customerContactColumn.DataPropertyName = "ContactPerson";
        customerContactColumn.HeaderText = "Контактное лицо";
        customerContactColumn.MinimumWidth = 6;
        customerContactColumn.Name = "customerContactColumn";
        customerContactColumn.ReadOnly = true;
        // 
        // customerPhoneColumn
        // 
        customerPhoneColumn.DataPropertyName = "Phone";
        customerPhoneColumn.HeaderText = "Телефон";
        customerPhoneColumn.MinimumWidth = 6;
        customerPhoneColumn.Name = "customerPhoneColumn";
        customerPhoneColumn.ReadOnly = true;
        // 
        // customerAddressColumn
        // 
        customerAddressColumn.DataPropertyName = "Address";
        customerAddressColumn.HeaderText = "Адрес";
        customerAddressColumn.MinimumWidth = 6;
        customerAddressColumn.Name = "customerAddressColumn";
        customerAddressColumn.ReadOnly = true;
        // 
        // tabPageItems
        // 
        tabPageItems.Controls.Add(comboBoxItemDelivery);
        tabPageItems.Controls.Add(labelItemDelivery);
        tabPageItems.Controls.Add(numericItemPriceMax);
        tabPageItems.Controls.Add(numericItemPriceMin);
        tabPageItems.Controls.Add(labelItemPriceTo);
        tabPageItems.Controls.Add(labelItemPriceFrom);
        tabPageItems.Controls.Add(textBoxItemDescription);
        tabPageItems.Controls.Add(labelItemDescription);
        tabPageItems.Controls.Add(buttonItemClearFilter);
        tabPageItems.Controls.Add(buttonItemApplyFilter);
        tabPageItems.Controls.Add(buttonItemDelete);
        tabPageItems.Controls.Add(buttonItemEdit);
        tabPageItems.Controls.Add(buttonItemAdd);
        tabPageItems.Controls.Add(dataGridViewItems);
        tabPageItems.Location = new System.Drawing.Point(4, 29);
        tabPageItems.Name = "tabPageItems";
        tabPageItems.Padding = new System.Windows.Forms.Padding(3);
        tabPageItems.Size = new System.Drawing.Size(1226, 648);
        tabPageItems.TabIndex = 1;
        tabPageItems.Text = "Товары";
        tabPageItems.UseVisualStyleBackColor = true;
        // 
        // comboBoxItemDelivery
        // 
        comboBoxItemDelivery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBoxItemDelivery.FormattingEnabled = true;
        comboBoxItemDelivery.Items.AddRange(new object[] { "Все", "Только с доставкой", "Только без доставки" });
        comboBoxItemDelivery.Location = new System.Drawing.Point(441, 362);
        comboBoxItemDelivery.Name = "comboBoxItemDelivery";
        comboBoxItemDelivery.Size = new System.Drawing.Size(237, 28);
        comboBoxItemDelivery.TabIndex = 12;
        // 
        // labelItemDelivery
        // 
        labelItemDelivery.AutoSize = true;
        labelItemDelivery.Location = new System.Drawing.Point(441, 339);
        labelItemDelivery.Name = "labelItemDelivery";
        labelItemDelivery.Size = new System.Drawing.Size(143, 20);
        labelItemDelivery.TabIndex = 11;
        labelItemDelivery.Text = "Доставка (фильтр)";
        // 
        // numericItemPriceMax
        // 
        numericItemPriceMax.Location = new System.Drawing.Point(234, 363);
        numericItemPriceMax.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numericItemPriceMax.Name = "numericItemPriceMax";
        numericItemPriceMax.Size = new System.Drawing.Size(180, 27);
        numericItemPriceMax.TabIndex = 10;
        // 
        // numericItemPriceMin
        // 
        numericItemPriceMin.Location = new System.Drawing.Point(18, 363);
        numericItemPriceMin.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numericItemPriceMin.Name = "numericItemPriceMin";
        numericItemPriceMin.Size = new System.Drawing.Size(180, 27);
        numericItemPriceMin.TabIndex = 9;
        // 
        // labelItemPriceTo
        // 
        labelItemPriceTo.AutoSize = true;
        labelItemPriceTo.Location = new System.Drawing.Point(234, 340);
        labelItemPriceTo.Name = "labelItemPriceTo";
        labelItemPriceTo.Size = new System.Drawing.Size(28, 20);
        labelItemPriceTo.TabIndex = 8;
        labelItemPriceTo.Text = "До";
        // 
        // labelItemPriceFrom
        // 
        labelItemPriceFrom.AutoSize = true;
        labelItemPriceFrom.Location = new System.Drawing.Point(18, 340);
        labelItemPriceFrom.Name = "labelItemPriceFrom";
        labelItemPriceFrom.Size = new System.Drawing.Size(26, 20);
        labelItemPriceFrom.TabIndex = 7;
        labelItemPriceFrom.Text = "От";
        // 
        // textBoxItemDescription
        // 
        textBoxItemDescription.Location = new System.Drawing.Point(18, 301);
        textBoxItemDescription.Name = "textBoxItemDescription";
        textBoxItemDescription.Size = new System.Drawing.Size(660, 27);
        textBoxItemDescription.TabIndex = 6;
        // 
        // labelItemDescription
        // 
        labelItemDescription.AutoSize = true;
        labelItemDescription.Location = new System.Drawing.Point(18, 278);
        labelItemDescription.Name = "labelItemDescription";
        labelItemDescription.Size = new System.Drawing.Size(83, 20);
        labelItemDescription.TabIndex = 5;
        labelItemDescription.Text = "Описание";
        // 
        // buttonItemClearFilter
        // 
        buttonItemClearFilter.Location = new System.Drawing.Point(1019, 318);
        buttonItemClearFilter.Name = "buttonItemClearFilter";
        buttonItemClearFilter.Size = new System.Drawing.Size(200, 32);
        buttonItemClearFilter.TabIndex = 4;
        buttonItemClearFilter.Text = "Очистить фильтр";
        buttonItemClearFilter.UseVisualStyleBackColor = true;
        buttonItemClearFilter.Click += buttonItemClearFilter_Click;
        // 
        // buttonItemApplyFilter
        // 
        buttonItemApplyFilter.Location = new System.Drawing.Point(815, 318);
        buttonItemApplyFilter.Name = "buttonItemApplyFilter";
        buttonItemApplyFilter.Size = new System.Drawing.Size(198, 32);
        buttonItemApplyFilter.TabIndex = 3;
        buttonItemApplyFilter.Text = "Применить фильтр";
        buttonItemApplyFilter.UseVisualStyleBackColor = true;
        buttonItemApplyFilter.Click += buttonItemApplyFilter_Click;
        // 
        // buttonItemDelete
        // 
        buttonItemDelete.Location = new System.Drawing.Point(430, 247);
        buttonItemDelete.Name = "buttonItemDelete";
        buttonItemDelete.Size = new System.Drawing.Size(200, 29);
        buttonItemDelete.TabIndex = 2;
        buttonItemDelete.Text = "Удалить";
        buttonItemDelete.UseVisualStyleBackColor = true;
        buttonItemDelete.Click += buttonItemDelete_Click;
        // 
        // buttonItemEdit
        // 
        buttonItemEdit.Location = new System.Drawing.Point(224, 247);
        buttonItemEdit.Name = "buttonItemEdit";
        buttonItemEdit.Size = new System.Drawing.Size(200, 29);
        buttonItemEdit.TabIndex = 1;
        buttonItemEdit.Text = "Редактировать";
        buttonItemEdit.UseVisualStyleBackColor = true;
        buttonItemEdit.Click += buttonItemEdit_Click;
        // 
        // buttonItemAdd
        // 
        buttonItemAdd.Location = new System.Drawing.Point(18, 247);
        buttonItemAdd.Name = "buttonItemAdd";
        buttonItemAdd.Size = new System.Drawing.Size(200, 29);
        buttonItemAdd.TabIndex = 0;
        buttonItemAdd.Text = "Добавить";
        buttonItemAdd.UseVisualStyleBackColor = true;
        buttonItemAdd.Click += buttonItemAdd_Click;
        // 
        // dataGridViewItems
        // 
        dataGridViewItems.AllowUserToAddRows = false;
        dataGridViewItems.AllowUserToDeleteRows = false;
        dataGridViewItems.AllowUserToOrderColumns = true;
        dataGridViewItems.AutoGenerateColumns = false;
        dataGridViewItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { itemIdColumn, itemDescriptionColumn, itemPriceColumn, itemDeliveryColumn });
        dataGridViewItems.DataSource = itemBindingSource;
        dataGridViewItems.Location = new System.Drawing.Point(6, 6);
        dataGridViewItems.MultiSelect = false;
        dataGridViewItems.Name = "dataGridViewItems";
        dataGridViewItems.ReadOnly = true;
        dataGridViewItems.RowHeadersWidth = 51;
        dataGridViewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dataGridViewItems.Size = new System.Drawing.Size(1214, 235);
        dataGridViewItems.TabIndex = 0;
        // 
        // itemIdColumn
        // 
        itemIdColumn.DataPropertyName = "ItemId";
        itemIdColumn.HeaderText = "ID";
        itemIdColumn.MinimumWidth = 6;
        itemIdColumn.Name = "itemIdColumn";
        itemIdColumn.ReadOnly = true;
        itemIdColumn.Visible = false;
        // 
        // itemDescriptionColumn
        // 
        itemDescriptionColumn.DataPropertyName = "Description";
        itemDescriptionColumn.HeaderText = "Описание";
        itemDescriptionColumn.MinimumWidth = 6;
        itemDescriptionColumn.Name = "itemDescriptionColumn";
        itemDescriptionColumn.ReadOnly = true;
        // 
        // itemPriceColumn
        // 
        itemPriceColumn.DataPropertyName = "Price";
        itemPriceColumn.HeaderText = "Цена";
        itemPriceColumn.MinimumWidth = 6;
        itemPriceColumn.Name = "itemPriceColumn";
        itemPriceColumn.ReadOnly = true;
        // 
        // itemDeliveryColumn
        // 
        itemDeliveryColumn.DataPropertyName = "Delivery";
        itemDeliveryColumn.HeaderText = "Доставка";
        itemDeliveryColumn.MinimumWidth = 6;
        itemDeliveryColumn.Name = "itemDeliveryColumn";
        itemDeliveryColumn.ReadOnly = true;
        // 
        // tabPageOrders
        // 
        tabPageOrders.Controls.Add(buttonOrderImportExcel);
        tabPageOrders.Controls.Add(buttonOrderExportExcel);
        tabPageOrders.Controls.Add(buttonOrderGenerateReport);
        tabPageOrders.Controls.Add(buttonOrderGenerateInvoice);
        tabPageOrders.Controls.Add(buttonOrderClearFilter);
        tabPageOrders.Controls.Add(buttonOrderApplyFilter);
        tabPageOrders.Controls.Add(numericOrderQuantityMax);
        tabPageOrders.Controls.Add(numericOrderQuantityMin);
        tabPageOrders.Controls.Add(labelOrderQuantityTo);
        tabPageOrders.Controls.Add(labelOrderQuantityFrom);
        tabPageOrders.Controls.Add(dateTimePickerOrderDate);
        tabPageOrders.Controls.Add(labelOrderDate);
        tabPageOrders.Controls.Add(comboBoxOrderItem);
        tabPageOrders.Controls.Add(labelOrderItem);
        tabPageOrders.Controls.Add(comboBoxOrderCustomer);
        tabPageOrders.Controls.Add(labelOrderCustomer);
        tabPageOrders.Controls.Add(buttonOrderDelete);
        tabPageOrders.Controls.Add(buttonOrderEdit);
        tabPageOrders.Controls.Add(buttonOrderAdd);
        tabPageOrders.Controls.Add(dataGridViewOrders);
        tabPageOrders.Location = new System.Drawing.Point(4, 29);
        tabPageOrders.Name = "tabPageOrders";
        tabPageOrders.Padding = new System.Windows.Forms.Padding(3);
        tabPageOrders.Size = new System.Drawing.Size(1226, 648);
        tabPageOrders.TabIndex = 2;
        tabPageOrders.Text = "Заказы";
        tabPageOrders.UseVisualStyleBackColor = true;
        // 
        // buttonOrderImportExcel
        // 
        buttonOrderImportExcel.Location = new System.Drawing.Point(621, 404);
        buttonOrderImportExcel.Name = "buttonOrderImportExcel";
        buttonOrderImportExcel.Size = new System.Drawing.Size(195, 32);
        buttonOrderImportExcel.TabIndex = 18;
        buttonOrderImportExcel.Text = "Импорт из Excel";
        buttonOrderImportExcel.UseVisualStyleBackColor = true;
        buttonOrderImportExcel.Click += buttonOrderImportExcel_Click;
        // 
        // buttonOrderExportExcel
        // 
        buttonOrderExportExcel.Location = new System.Drawing.Point(420, 404);
        buttonOrderExportExcel.Name = "buttonOrderExportExcel";
        buttonOrderExportExcel.Size = new System.Drawing.Size(195, 32);
        buttonOrderExportExcel.TabIndex = 17;
        buttonOrderExportExcel.Text = "Экспорт в Excel";
        buttonOrderExportExcel.UseVisualStyleBackColor = true;
        buttonOrderExportExcel.Click += buttonOrderExportExcel_Click;
        // 
        // buttonOrderGenerateReport
        // 
        buttonOrderGenerateReport.Location = new System.Drawing.Point(219, 404);
        buttonOrderGenerateReport.Name = "buttonOrderGenerateReport";
        buttonOrderGenerateReport.Size = new System.Drawing.Size(195, 32);
        buttonOrderGenerateReport.TabIndex = 16;
        buttonOrderGenerateReport.Text = "Отчет по заказам";
        buttonOrderGenerateReport.UseVisualStyleBackColor = true;
        buttonOrderGenerateReport.Click += buttonOrderGenerateReport_Click;
        // 
        // buttonOrderGenerateInvoice
        // 
        buttonOrderGenerateInvoice.Location = new System.Drawing.Point(18, 404);
        buttonOrderGenerateInvoice.Name = "buttonOrderGenerateInvoice";
        buttonOrderGenerateInvoice.Size = new System.Drawing.Size(195, 32);
        buttonOrderGenerateInvoice.TabIndex = 15;
        buttonOrderGenerateInvoice.Text = "Сформировать счет";
        buttonOrderGenerateInvoice.UseVisualStyleBackColor = true;
        buttonOrderGenerateInvoice.Click += buttonOrderGenerateInvoice_Click;
        // 
        // buttonOrderClearFilter
        // 
        buttonOrderClearFilter.Location = new System.Drawing.Point(1019, 318);
        buttonOrderClearFilter.Name = "buttonOrderClearFilter";
        buttonOrderClearFilter.Size = new System.Drawing.Size(200, 32);
        buttonOrderClearFilter.TabIndex = 14;
        buttonOrderClearFilter.Text = "Очистить фильтр";
        buttonOrderClearFilter.UseVisualStyleBackColor = true;
        buttonOrderClearFilter.Click += buttonOrderClearFilter_Click;
        // 
        // buttonOrderApplyFilter
        // 
        buttonOrderApplyFilter.Location = new System.Drawing.Point(815, 318);
        buttonOrderApplyFilter.Name = "buttonOrderApplyFilter";
        buttonOrderApplyFilter.Size = new System.Drawing.Size(198, 32);
        buttonOrderApplyFilter.TabIndex = 13;
        buttonOrderApplyFilter.Text = "Применить фильтр";
        buttonOrderApplyFilter.UseVisualStyleBackColor = true;
        buttonOrderApplyFilter.Click += buttonOrderApplyFilter_Click;
        // 
        // numericOrderQuantityMax
        // 
        numericOrderQuantityMax.Location = new System.Drawing.Point(612, 364);
        numericOrderQuantityMax.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        numericOrderQuantityMax.Name = "numericOrderQuantityMax";
        numericOrderQuantityMax.Size = new System.Drawing.Size(180, 27);
        numericOrderQuantityMax.TabIndex = 12;
        // 
        // numericOrderQuantityMin
        // 
        numericOrderQuantityMin.Location = new System.Drawing.Point(410, 364);
        numericOrderQuantityMin.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        numericOrderQuantityMin.Name = "numericOrderQuantityMin";
        numericOrderQuantityMin.Size = new System.Drawing.Size(180, 27);
        numericOrderQuantityMin.TabIndex = 11;
        // 
        // labelOrderQuantityTo
        // 
        labelOrderQuantityTo.AutoSize = true;
        labelOrderQuantityTo.Location = new System.Drawing.Point(612, 341);
        labelOrderQuantityTo.Name = "labelOrderQuantityTo";
        labelOrderQuantityTo.Size = new System.Drawing.Size(28, 20);
        labelOrderQuantityTo.TabIndex = 10;
        labelOrderQuantityTo.Text = "До";
        // 
        // labelOrderQuantityFrom
        // 
        labelOrderQuantityFrom.AutoSize = true;
        labelOrderQuantityFrom.Location = new System.Drawing.Point(410, 341);
        labelOrderQuantityFrom.Name = "labelOrderQuantityFrom";
        labelOrderQuantityFrom.Size = new System.Drawing.Size(26, 20);
        labelOrderQuantityFrom.TabIndex = 9;
        labelOrderQuantityFrom.Text = "От";
        // 
        // dateTimePickerOrderDate
        // 
        dateTimePickerOrderDate.Location = new System.Drawing.Point(18, 364);
        dateTimePickerOrderDate.Name = "dateTimePickerOrderDate";
        dateTimePickerOrderDate.ShowCheckBox = true;
        dateTimePickerOrderDate.Size = new System.Drawing.Size(366, 27);
        dateTimePickerOrderDate.TabIndex = 8;
        dateTimePickerOrderDate.ValueChanged += dateTimePickerOrderDate_ValueChanged;
        // 
        // labelOrderDate
        // 
        labelOrderDate.AutoSize = true;
        labelOrderDate.Location = new System.Drawing.Point(18, 341);
        labelOrderDate.Name = "labelOrderDate";
        labelOrderDate.Size = new System.Drawing.Size(94, 20);
        labelOrderDate.TabIndex = 7;
        labelOrderDate.Text = "Дата заказа";
        // 
        // comboBoxOrderItem
        // 
        comboBoxOrderItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBoxOrderItem.FormattingEnabled = true;
        comboBoxOrderItem.Location = new System.Drawing.Point(410, 301);
        comboBoxOrderItem.Name = "comboBoxOrderItem";
        comboBoxOrderItem.Size = new System.Drawing.Size(382, 28);
        comboBoxOrderItem.TabIndex = 6;
        // 
        // labelOrderItem
        // 
        labelOrderItem.AutoSize = true;
        labelOrderItem.Location = new System.Drawing.Point(410, 278);
        labelOrderItem.Name = "labelOrderItem";
        labelOrderItem.Size = new System.Drawing.Size(47, 20);
        labelOrderItem.TabIndex = 5;
        labelOrderItem.Text = "Товар";
        // 
        // comboBoxOrderCustomer
        // 
        comboBoxOrderCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBoxOrderCustomer.FormattingEnabled = true;
        comboBoxOrderCustomer.Location = new System.Drawing.Point(18, 301);
        comboBoxOrderCustomer.Name = "comboBoxOrderCustomer";
        comboBoxOrderCustomer.Size = new System.Drawing.Size(366, 28);
        comboBoxOrderCustomer.TabIndex = 4;
        // 
        // labelOrderCustomer
        // 
        labelOrderCustomer.AutoSize = true;
        labelOrderCustomer.Location = new System.Drawing.Point(18, 278);
        labelOrderCustomer.Name = "labelOrderCustomer";
        labelOrderCustomer.Size = new System.Drawing.Size(61, 20);
        labelOrderCustomer.TabIndex = 3;
        labelOrderCustomer.Text = "Клиент";
        // 
        // buttonOrderDelete
        // 
        buttonOrderDelete.Location = new System.Drawing.Point(430, 247);
        buttonOrderDelete.Name = "buttonOrderDelete";
        buttonOrderDelete.Size = new System.Drawing.Size(200, 29);
        buttonOrderDelete.TabIndex = 2;
        buttonOrderDelete.Text = "Удалить";
        buttonOrderDelete.UseVisualStyleBackColor = true;
        buttonOrderDelete.Click += buttonOrderDelete_Click;
        // 
        // buttonOrderEdit
        // 
        buttonOrderEdit.Location = new System.Drawing.Point(224, 247);
        buttonOrderEdit.Name = "buttonOrderEdit";
        buttonOrderEdit.Size = new System.Drawing.Size(200, 29);
        buttonOrderEdit.TabIndex = 1;
        buttonOrderEdit.Text = "Редактировать";
        buttonOrderEdit.UseVisualStyleBackColor = true;
        buttonOrderEdit.Click += buttonOrderEdit_Click;
        // 
        // buttonOrderAdd
        // 
        buttonOrderAdd.Location = new System.Drawing.Point(18, 247);
        buttonOrderAdd.Name = "buttonOrderAdd";
        buttonOrderAdd.Size = new System.Drawing.Size(200, 29);
        buttonOrderAdd.TabIndex = 0;
        buttonOrderAdd.Text = "Добавить";
        buttonOrderAdd.UseVisualStyleBackColor = true;
        buttonOrderAdd.Click += buttonOrderAdd_Click;
        // 
        // dataGridViewOrders
        // 
        dataGridViewOrders.AllowUserToAddRows = false;
        dataGridViewOrders.AllowUserToDeleteRows = false;
        dataGridViewOrders.AllowUserToOrderColumns = true;
        dataGridViewOrders.AutoGenerateColumns = false;
        dataGridViewOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { orderIdColumn, orderCustomerColumn, orderItemColumn, orderQuantityColumn, orderDateColumn, orderTotalColumn });
        dataGridViewOrders.DataSource = orderBindingSource;
        dataGridViewOrders.Location = new System.Drawing.Point(6, 6);
        dataGridViewOrders.MultiSelect = false;
        dataGridViewOrders.Name = "dataGridViewOrders";
        dataGridViewOrders.ReadOnly = true;
        dataGridViewOrders.RowHeadersWidth = 51;
        dataGridViewOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dataGridViewOrders.Size = new System.Drawing.Size(1214, 235);
        dataGridViewOrders.TabIndex = 0;
        // 
        // orderIdColumn
        // 
        orderIdColumn.DataPropertyName = "OrderId";
        orderIdColumn.HeaderText = "ID";
        orderIdColumn.MinimumWidth = 6;
        orderIdColumn.Name = "orderIdColumn";
        orderIdColumn.ReadOnly = true;
        orderIdColumn.Visible = false;
        // 
        // orderCustomerColumn
        // 
        orderCustomerColumn.DataPropertyName = "Customer";
        orderCustomerColumn.HeaderText = "Клиент";
        orderCustomerColumn.MinimumWidth = 6;
        orderCustomerColumn.Name = "orderCustomerColumn";
        orderCustomerColumn.ReadOnly = true;
        // 
        // orderItemColumn
        // 
        orderItemColumn.DataPropertyName = "Item";
        orderItemColumn.HeaderText = "Товар";
        orderItemColumn.MinimumWidth = 6;
        orderItemColumn.Name = "orderItemColumn";
        orderItemColumn.ReadOnly = true;
        // 
        // orderQuantityColumn
        // 
        orderQuantityColumn.DataPropertyName = "Quantity";
        orderQuantityColumn.HeaderText = "Кол-во";
        orderQuantityColumn.MinimumWidth = 6;
        orderQuantityColumn.Name = "orderQuantityColumn";
        orderQuantityColumn.ReadOnly = true;
        // 
        // orderDateColumn
        // 
        orderDateColumn.DataPropertyName = "OrderDate";
        orderDateColumn.HeaderText = "Дата";
        orderDateColumn.MinimumWidth = 6;
        orderDateColumn.Name = "orderDateColumn";
        orderDateColumn.ReadOnly = true;
        // 
        // orderTotalColumn
        // 
        orderTotalColumn.DataPropertyName = "TotalCost";
        orderTotalColumn.HeaderText = "Сумма";
        orderTotalColumn.MinimumWidth = 6;
        orderTotalColumn.Name = "orderTotalColumn";
        orderTotalColumn.ReadOnly = true;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        ClientSize = new System.Drawing.Size(1234, 681);
        Controls.Add(tabControlMain);
        Name = "MainForm";
        Text = "Order Management";
        ((System.ComponentModel.ISupportInitialize)customerBindingSource).EndInit();
        ((System.ComponentModel.ISupportInitialize)itemBindingSource).EndInit();
        ((System.ComponentModel.ISupportInitialize)orderBindingSource).EndInit();
        tabControlMain.ResumeLayout(false);
        tabPageCustomers.ResumeLayout(false);
        tabPageCustomers.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).EndInit();
        tabPageItems.ResumeLayout(false);
        tabPageItems.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numericItemPriceMax).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericItemPriceMin).EndInit();
        ((System.ComponentModel.ISupportInitialize)dataGridViewItems).EndInit();
        tabPageOrders.ResumeLayout(false);
        tabPageOrders.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numericOrderQuantityMax).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericOrderQuantityMin).EndInit();
        ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.BindingSource customerBindingSource;
    private System.Windows.Forms.BindingSource itemBindingSource;
    private System.Windows.Forms.BindingSource orderBindingSource;
    private System.Windows.Forms.TabControl tabControlMain;
    private System.Windows.Forms.TabPage tabPageCustomers;
    private System.Windows.Forms.Button buttonCustomerClearFilter;
    private System.Windows.Forms.Button buttonCustomerApplyFilter;
    private System.Windows.Forms.TextBox textBoxCustomerAddress;
    private System.Windows.Forms.Label labelCustomerAddress;
    private System.Windows.Forms.TextBox textBoxCustomerPhone;
    private System.Windows.Forms.Label labelCustomerPhone;
    private System.Windows.Forms.TextBox textBoxCustomerContact;
    private System.Windows.Forms.Label labelCustomerContact;
    private System.Windows.Forms.TextBox textBoxCustomerName;
    private System.Windows.Forms.Label labelCustomerName;
    private System.Windows.Forms.Button buttonCustomerDelete;
    private System.Windows.Forms.Button buttonCustomerEdit;
    private System.Windows.Forms.Button buttonCustomerAdd;
    private System.Windows.Forms.DataGridView dataGridViewCustomers;
    private System.Windows.Forms.DataGridViewTextBoxColumn customerIdColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn customerNameColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn customerContactColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn customerPhoneColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn customerAddressColumn;
    private System.Windows.Forms.TabPage tabPageItems;
    private System.Windows.Forms.ComboBox comboBoxItemDelivery;
    private System.Windows.Forms.Label labelItemDelivery;
    private System.Windows.Forms.NumericUpDown numericItemPriceMax;
    private System.Windows.Forms.NumericUpDown numericItemPriceMin;
    private System.Windows.Forms.Label labelItemPriceTo;
    private System.Windows.Forms.Label labelItemPriceFrom;
    private System.Windows.Forms.TextBox textBoxItemDescription;
    private System.Windows.Forms.Label labelItemDescription;
    private System.Windows.Forms.Button buttonItemClearFilter;
    private System.Windows.Forms.Button buttonItemApplyFilter;
    private System.Windows.Forms.Button buttonItemDelete;
    private System.Windows.Forms.Button buttonItemEdit;
    private System.Windows.Forms.Button buttonItemAdd;
    private System.Windows.Forms.DataGridView dataGridViewItems;
    private System.Windows.Forms.DataGridViewTextBoxColumn itemIdColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn itemDescriptionColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn itemPriceColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn itemDeliveryColumn;
    private System.Windows.Forms.TabPage tabPageOrders;
    private System.Windows.Forms.Button buttonOrderGenerateReport;
    private System.Windows.Forms.Button buttonOrderGenerateInvoice;
    private System.Windows.Forms.Button buttonOrderExportExcel;
    private System.Windows.Forms.Button buttonOrderImportExcel;
    private System.Windows.Forms.Button buttonOrderClearFilter;
    private System.Windows.Forms.Button buttonOrderApplyFilter;
    private System.Windows.Forms.NumericUpDown numericOrderQuantityMax;
    private System.Windows.Forms.NumericUpDown numericOrderQuantityMin;
    private System.Windows.Forms.Label labelOrderQuantityTo;
    private System.Windows.Forms.Label labelOrderQuantityFrom;
    private System.Windows.Forms.DateTimePicker dateTimePickerOrderDate;
    private System.Windows.Forms.Label labelOrderDate;
    private System.Windows.Forms.ComboBox comboBoxOrderItem;
    private System.Windows.Forms.Label labelOrderItem;
    private System.Windows.Forms.ComboBox comboBoxOrderCustomer;
    private System.Windows.Forms.Label labelOrderCustomer;
    private System.Windows.Forms.Button buttonOrderDelete;
    private System.Windows.Forms.Button buttonOrderEdit;
    private System.Windows.Forms.Button buttonOrderAdd;
    private System.Windows.Forms.DataGridView dataGridViewOrders;
    private System.Windows.Forms.DataGridViewTextBoxColumn orderIdColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn orderCustomerColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn orderItemColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn orderQuantityColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn orderDateColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn orderTotalColumn;

    #endregion
}