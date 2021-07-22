$(function () {
    var createModal = new abp.ModalManager(abp.appPath + 'Admin/CustomerDetails/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Admin/CustomerDetails/EditModal');

    var dataTable = $('#dataTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.projectDemo.entities.customerDetails.customerDetail.getList),
            columnDefs: [
                {
                    title: "Action",
                    rowAction: {
                        items:
                            [
                                {
                                    text: "Edit",
                                    visible: abp.auth.isGranted('ProjectDemo.CustomerDetail.Edit'),
                                    action: function (data) {
                                        editModal.open({ Id: data.record.id });
                                    }
                                },
                                {
                                    text: "Delete",
                                    visible: abp.auth.isGranted('ProjectDemo.CustomerDetail.Delete'),
                                    confirmMessage: function (data) {
                                        return "Are you sure you wish to delete this time";
                                    },
                                    action: function (data) {
                                        acme.projectDemo.entities.customerDetails.customerDetail
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info("Successfully Deleted");
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: "First Name",
                    data: "firstName"
                },
                {
                    title: "Last Name",
                    data: "lastName"
                },
                {
                    title: "DateOfBirth",
                    data: "dateOfBirth",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    }
                },
                {
                    title: "Address",
                    data: "address"
                }, 
                {
                    title: "ProfilePhoto",
                    data: "profilePhoto"
                },
                {
                    title: "phoneNumber",
                    data: "phoneNumber"
                },
                {
                    title: "UploadDocuments",
                    data: "uploadDocuments"
                },
                {
                    title: "Job",
                    data: "job"
                },
                {
                    title: "BankDetails",
                    data: "bankDetails"
                },
                {
                    title: "ShippingAddress",
                    data: "shippingAddress"
                },
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
        abp.notify.info("Customer Created Successfully");
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
        abp.notify.info("Customer Edited Successfully");
    });


    $('#createCustomerBtn').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});