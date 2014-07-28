/// <reference path="knockout-3.1.0.js" />
/// <reference path="jquery-1.11.1.min.js" />
var AllowanceSavingsViewModel = function (allowAnceSavingsViewModelID, baseRESTAPIUrl) {
    SP.SOD.executeFunc('sp.js', 'SP.ClientContext', function () { });
    var _statusID = '';
    var _self = this;
    var _baseRESTAPIUrl = baseRESTAPIUrl;

    function OnError(jqXHR, status, errorMessage) {
        SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK);
        _statusID = SP.UI.Status.addStatus('Error', errorMessage, true);
        SP.UI.Status.setStatusPriColor(_statusID, 'red');
    }

    function OnSuccess(data, status, jqXHR)
    {
        SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK);
        console.log(data);
    }

    this.AimDesired = ko.observable(0);
    this.NumberMonth = ko.observable(0);
    this.Rentability = ko.observable(0.0);

    this.Submit = function () {
        SP.UI.ModalDialog.showWaitScreenWithNoClose(SP.Res.dialogLoading15);
        $.ajax(
            {
                cache: false,
                url: _baseRESTAPIUrl + '/api/SimuladorFinanciero/',
                type: 'GET',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                data: {
                    aimDesired: _self.AimDesired(),
                    numberMonth: _self.NumberMonth(),
                    rentability: _self.Rentability()
                },
                success: OnSuccess,
                error: OnError
            }
        );
    }

}