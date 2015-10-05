define(["sitecore"], function (Sitecore) {
    var model = Sitecore.Definitions.Models.ControlModel.extend({
        initialize: function (options) {
            this._super();
            app = this;
            app.set("jobitems", '');
            app.set("text", "false");
            this.GetJobs(app);
            app.on("change:jobitems", this.callback, null);
            console.log("s");
        },
        callback: function () {
            this.GetJobs();
        },
        GetJobs: function () {
            var app = this;

            jQuery.ajax({
                type: "GET",
                dataType: "json",
                data: { 'excludeFinishedJobs': app.get("text") },
                url: "/api/sitecore/SitecoreJobs/GetSitecoreJobs",
                cache: false,
                success: function (data) {
                    app.set("jobitems", data);
                },
                error: function () {
                    console.log("There was an error. Try again please!");
                }
            });
        }
    });

    var view = Sitecore.Definitions.Views.ControlView.extend({
        initialize: function (options) {
            this._super();
        }
    });

    Sitecore.Factories.createComponent("SitecoreJobsList", model, view, ".sc-SitecoreJobsList");
});
