# SkillEditorBasedOnSlate
基于ParadoxNotion Slate的帧同步技能编辑器，博客链接：[ParadoxNotion-Slate学习笔记与拓展计划](https://www.lfzxb.top/unity-slate-study-and-extendplan/)

项目使用了两款插件，请自行购买并导入Assets/Plugins/目录中

 - [ParadoxNotion-Slate](https://slate.paradoxnotion.com/)
 - [Odin](https://odininspector.com/)

## 功能列表

- [x] 基于帧同步的技能系统运行时
- [ ] 技能数据的编辑与导出
- [ ] 测试用例

## 更改内容

由于我们需要用Odin在Inpsector绘制内容，所以需要更改Slate自带的CustomEditor绘制

```csharp
public class ActionClipInspector : OdinEditor

[CustomEditor(typeof(Cutscene), true)]
public class CutsceneInspector : OdinEditor
```

由于我们为了分离数据运行时逻辑，采用了较为复杂的引用和层级关系，所以需要借助Odin的序列化，也就需要更改Slate ActionClip的继承对象为SerializedMonoBehaviour

```csharp
abstract public class ActionClip : SerializedMonoBehaviour, IDirectable, IKeyable
```

出于个人喜好和可拓展性的考虑，重写了CutSceneEditor部分代码

```csharp
//left - the groups and tracks info and option per group/track
void ShowGroupsAndTracksList(Rect leftRect) {
    var e = Event.current;
    //allow resize list width
    var scaleRect = new Rect(leftRect.xMax - 4, leftRect.yMin, 4, leftRect.height);
    AddCursorRect(scaleRect, MouseCursor.ResizeHorizontal);
    if ( e.type == EventType.MouseDown && e.button == 0 && scaleRect.Contains(e.mousePosition) ) { isResizingLeftMargin = true; e.Use(); }
    if ( isResizingLeftMargin ) { LEFT_MARGIN = e.mousePosition.x + 2; }
    if ( e.rawType == EventType.MouseUp ) { isResizingLeftMargin = false; }
    GUI.enabled = cutscene.currentTime <= 0;
    //starting height && search.
    var nextYPos = FIRST_GROUP_TOP_MARGIN;
    var wasEnabled = GUI.enabled;
    GUI.enabled = true;
    var collapseAllRect = Rect.MinMaxRect(leftRect.x + 2, leftRect.y + 2, 18, leftRect.y + 16);
    var searchRect = Rect.MinMaxRect(collapseAllRect.x + 18, leftRect.y + 4, leftRect.xMax - 32, leftRect.y + 20 - 1);
    var searchCancelRect = Rect.MinMaxRect(searchRect.xMax, searchRect.y, leftRect.xMax - 16, searchRect.yMax);
    var createGroupRect = new Rect(searchCancelRect.xMax, searchCancelRect.yMin + 2, 10, 10);
    var anyExpanded = cutscene.groups.Any(g => !g.isCollapsed);
    AddCursorRect(collapseAllRect, MouseCursor.Link);
    GUI.color = Color.white.WithAlpha(0.5f);
    if ( GUI.Button(collapseAllRect, anyExpanded ? "▼" : "►", (GUIStyle)"label") ) {
        foreach ( var group in cutscene.groups ) {
            group.isCollapsed = anyExpanded;
        }
    }
    GUI.color = Color.white;
    searchString = EditorGUI.TextField(searchRect, searchString, (GUIStyle)"ToolbarSeachTextField");
    if ( GUI.Button(searchCancelRect, string.Empty, (GUIStyle)"ToolbarSeachCancelButton") ) {
        searchString = string.Empty;
        GUIUtility.keyboardControl = 0;
    }
    if (GUI.Button(createGroupRect, Slate.Styles.plusIcon, GUIStyle.none))
    {
        GenericMenu genericMenu = new GenericMenu();
        genericMenu.AddItem(new GUIContent("Add Actor Group"), false, data => {                 
            var newGroup = cutscene.AddGroup<ActorGroup>(null).AddTrack<ActorActionTrack>();
            CutsceneUtility.selectedObject = newGroup;}, null);
        genericMenu.AddItem(new GUIContent("Add Skill Group"), false, data => {                 
            var newGroup = cutscene.AddGroup<ST_ParadoxNotionGroup>(null).AddTrack<ST_ParadoxNotionTrack>();
            CutsceneUtility.selectedObject = newGroup;}, null);
        genericMenu.ShowAsContext();
    }
    GUI.enabled = wasEnabled;
    //begin area for left Rect
    GUI.BeginGroup(leftRect);
    ShowListGroups(e, ref nextYPos);
    GUI.EndGroup();
    //store total height required
    totalHeight = nextYPos;
    //Simple button to add empty group for convenience
    var addButtonY = totalHeight + TOP_MARGIN + TOOLBAR_HEIGHT + 20;
    var addRect = Rect.MinMaxRect(leftRect.xMin + 10, addButtonY, leftRect.xMax - 10, addButtonY + 20);
    GUI.color = Color.white.WithAlpha(0.5f);
    //clear picks
    if ( e.rawType == EventType.MouseUp ) {
        pickedGroup = null;
        pickedTrack = null;
    }
    GUI.enabled = true;
    GUI.color = Color.white;
} 
```