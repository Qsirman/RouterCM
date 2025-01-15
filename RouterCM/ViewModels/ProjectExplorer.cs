using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RouterCM.ViewModels
{
    public enum ExplorerItemType
    {
        Unknown = -1,
        ProjectGroup,
        Project,
        ComManager,
        Module,
        Port,
        Dev
    }

    public class ExplorerItem
    {
        public ExplorerItemType Type { get; set; } = ExplorerItemType.Unknown;
        public string Name { get; set; }
        public ExplorerItem() { }
        public ExplorerItem(string name, ObservableCollection<ExplorerItem> children, ExplorerItemType type) { Name = name; Type = type; Children = children; }
        public ExplorerItem(string name, ExplorerItemType type) { Name = name; Type = type; }
        public ObservableCollection<ExplorerItem> Children { get; } = new();
    }

    public class ProjectExplorer
    {
        public string Name { get; set; }
        public ProjectExplorer() { }
        public ProjectExplorer(string name, ObservableCollection<ExplorerItem> items) { Name = name; Items = items; }
        public ObservableCollection<ExplorerItem> Items { get; } = new();
    }

    //public class ProjectExplorer
    //{
    //    public string name { get; set; }
    //    public ProjectExplorer() { }
    //    public ProjectExplorer(string _name, ObservableCollection<ProjectGroup> _project_groups) { name = _name; project_groups = _project_groups; }
    //    public ObservableCollection<ProjectGroup> project_groups { get; } = new();
    //}

    //public class ProjectGroup
    //{
    //    public string name { get; set; }
    //    public ProjectGroup() { }
    //    public ProjectGroup(string _name, ObservableCollection<Project> _projects) { name = _name; projects = _projects; }
    //    public ProjectGroup(string _name) { name = _name; }
    //    public ObservableCollection<Project> projects { get; } = new();
    //}

    //public class Project
    //{
    //    public string name { get; set; }
    //    public Project() { }
    //    public Project(string _name, ObservableCollection<ComManager> _com_managers) { name = _name; com_managers = _com_managers; }
    //    public Project(string _name) { name = _name; }
    //    public ObservableCollection<ComManager> com_managers { get; } = new();
    //}

    //public class ComManager
    //{
    //    public string name { get; set; }
    //    public ComManager() { }
    //    public ComManager(string _name, ObservableCollection<Module> _modules) { name = _name; modules = _modules; }
    //    public ComManager(string _name) { name = _name; }
    //    public ObservableCollection<Module> modules { get; } = new();
    //}

    //public class Module
    //{
    //    public string name { get; set; }
    //    public Module() { }
    //    public Module(string _name, ObservableCollection<Port> _ports) { name = _name; ports = _ports; }
    //    public Module(string _name) { name = _name; }
    //    public ObservableCollection<Port> ports { get; } = new();
    //}

    //public class Port
    //{
    //    public string name { get; set; }
    //    public Port() { }
    //    public Port(string _name, ObservableCollection<Dev> _devs) { name = _name; devs = _devs; }
    //    public Port(string _name) { name = _name; }
    //    public ObservableCollection<Dev> devs { get; } = new();
    //}

    //public class Dev
    //{
    //    public string name { get; set; }
    //    public Dev() { }
    //    public Dev(string _name) { name = _name; }
    //}

}
