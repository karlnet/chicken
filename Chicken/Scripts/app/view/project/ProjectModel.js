Ext.define('MyApp2.view.project.ProjectModel', {
    extend: 'Ext.app.ViewModel',
    alias: 'viewmodel.project',

    stores: {


        projectMenus: {
            type: 'menus'
        }
    },



});