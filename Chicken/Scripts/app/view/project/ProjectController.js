Ext.define('MyApp2.view.project.ProjectController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.project',
    // views: ['MyApp2.view.project.Project'],
    // requires: ['MyApp2.store.Devices', 'MyApp2.store.ProjectsTree'],

    init: function() {
        this.setCurrentView('app-deviceList');
    },

    onProjectMenuSelectionChange: function(tree, records, index, eOpts) {
        if (records && records.length > 0) {
            console.log("log...........", records[0].get('routeId'));
            this.setCurrentView(records[0].get('routeId'), { projectNo: records[0].get('id') });
        }
    },

    setCurrentView: function(view, params) {
        var contentPanel = this.getView().down('#contentPanel');

        //We skip rendering for the following scenarios:
        // * There is no contentPanel
        // * view xtype is not specified
        // * current view is the same
        if (!contentPanel || view === '' || (contentPanel.down() && contentPanel.down().xtype === view)) {
            return false;
        }

        Ext.suspendLayouts();

        contentPanel.removeAll(true);
        contentPanel.add(
            Ext.apply({
                xtype: view
            }, params)
        );

        Ext.resumeLayouts(true);

    },

    onGridCellItemClick: function(view, td, cellIndex, record) {
        if (cellIndex > 1) {
            this.setCurrentView('emaildetails', { record: record });
        } else if (cellIndex === 1) {
            //Invert selection
            record.set('favorite', !record.get('favorite'));
        }
    },

    beforeDetailsRender: function(view) {
        var record = view.record ? view.record : {};

        view.down('#mailBody').setHtml(record.get('contents'));
        view.down('#attachments').setData(record.get('attachments'));
        view.down('#emailSubjectContainer').setData(record.data ? record.data : {});
        view.down('#userImage').setSrc('resources/images/user-profile/' + record.get('user_id') + '.png');
    },



});