/// <reference path="knockout-3.1.0.js" />
/// <reference path="jquery-1.11.1.min.js" />
var AllowanceSavingsViewModel = function (allowAnceSavingsViewModelID, baseRESTAPIUrl, calljavascriptfunction, chatjavascriptfunction, schedulejavascriptfunction) {
    SP.SOD.executeFunc('sp.js', 'SP.ClientContext', function () { });
    var _statusID = '';
    var _self = this;
    var _baseRESTAPIUrl = baseRESTAPIUrl;
    var _calljavascriptfunction = calljavascriptfunction;
    var _chatjavascriptfunction = chatjavascriptfunction;
    var _schedulejavascriptfunction = schedulejavascriptfunction;

    function OnError(jqXHR, status, errorMessage) {
        SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK);
        _statusID = SP.UI.Status.addStatus('Error', errorMessage, true);
        SP.UI.Status.setStatusPriColor(_statusID, 'red');
    }

    function OnSuccess(data, status, jqXHR) {
        SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK);
        _self.Savings(data.formatMoney(2, '.', ','));
        GoToStep3();
    }

    this.Step1Visibility = ko.observable(true);
    this.Step2Visibility = ko.observable(false);
    this.Step3Visibility = ko.observable(false);

    this.AimDesired = ko.observable('');
    this.NumberMonth = ko.observable('');
    this.Rentability = ko.observable('');
    this.Savings = ko.observable();

    this.ShowSimulator = function () {
        GoToStep2();
    }

    this.Chat = function () { eval(_chatjavascriptfunction); }

    this.Schedule = function () { eval(_schedulejavascriptfunction); }

    this.Call = function () { eval(_calljavascriptfunction); }

    function GoToStep2() {
        _self.Step1Visibility(false);
        _self.Step2Visibility(true);
        _self.Step3Visibility(false);
    }

    function GoToStep3() {
        _self.Step1Visibility(false);
        _self.Step2Visibility(false);
        _self.Step3Visibility(true);
    }

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