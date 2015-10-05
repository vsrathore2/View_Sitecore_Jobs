define(["sitecore"], function (Sitecore) {
    var model = Sitecore.Definitions.Models.ControlModel.extend({
        initialize: function (options) {
            this._super();
            app = this;
            app.set("jobitems", '');
            app.set("text", "");
            app.set("nojobstext", 'No Sitecore Jobs Found!');
            app.on("change:jobitems", this.callback, null);            
        },
        callback: function () {
            this.GetJobs();
        },
        GetJobs: function () {
            var app = this;
          
            jQuery.ajax({
                type: "GET",
                dataType: "json",
                data: { 'showAll': app.get("text") },
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

    Sitecore.Factories.createComponent("SitecoreJobs", model, view, ".sc-SitecoreJobs");
});
