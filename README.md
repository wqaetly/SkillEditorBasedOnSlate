# SkillEditorBasedOnSlate
基于ParadoxNotion Slate的帧同步技能编辑器，博客链接：[ParadoxNotion-Slate学习笔记与拓展计划](https://www.lfzxb.top/unity-slate-study-and-extendplan/)

项目使用了两款插件，请自行购买并导入Assets/Plugins/目录中

 - [ParadoxNotion-Slate](https://slate.paradoxnotion.com/)
 - [Odin](https://odininspector.com/)

## 功能列表

- [x] 基于帧同步的技能系统运行时
- [x] 重写Slate创建Group的编辑器界面代码
- [x] 部分Action库
- [x] 技能数据的编辑与导出
- [x] 测试用例

## 更改内容

下列更改内容需要您手动将链接中的文件替换到Slate插件中

由于我们需要用Odin在Inpsector绘制内容，所以需要更改Slate自带的CustomEditor绘制：

 - [替换Plugins/ParadoxNotion/SLATE Cinematic Sequencer/Design/Editor/Inspectors/ActionClipInspector.cs](https://github.com/wqaetly/SkillEditorBasedOnSlate/blob/main/SlateChangedFiles/ActionClipInspector.cs)
 - [替换Plugins/ParadoxNotion/SLATE Cinematic Sequencer/Design/Editor/Inspectors/CutsceneInspector.cs](https://github.com/wqaetly/SkillEditorBasedOnSlate/blob/main/SlateChangedFiles/CutsceneInspector.cs)

由于我们为了分离数据运行时逻辑，采用了较为复杂的引用和层级关系，所以需要借助Odin的序列化，也就需要更改Slate ActionClip的继承对象为SerializedMonoBehaviour：

 - [替换Plugins/ParadoxNotion/SLATE Cinematic Sequencer/Directables/Clips/Runtime/ActionTrack/ActorActions/ActionClip.cs](https://github.com/wqaetly/SkillEditorBasedOnSlate/blob/main/SlateChangedFiles/ActionClip.cs)

出于个人喜好和可拓展性的考虑，重写了CutSceneEditor部分代码：
 - [替换Plugins/ParadoxNotion/SLATE Cinematic Sequencer/Design/Editor/Windows/CutsceneEditor.cs](https://github.com/wqaetly/SkillEditorBasedOnSlate/blob/main/SlateChangedFiles/CutsceneEditor.cs)

现在支持从搜索栏左侧的加号按钮新增Group

![image](https://user-images.githubusercontent.com/35335061/129744492-0dceddb1-d5d3-457e-aac3-f32bbd8f362e.png)

![image](https://user-images.githubusercontent.com/35335061/129744543-807f9024-be36-484d-8d0d-35df9cf4136a.png)
