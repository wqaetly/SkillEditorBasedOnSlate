# SkillEditorBasedOnSlate
基于ParadoxNotion Slate的帧同步技能编辑器，博客链接：[ParadoxNotion-Slate学习笔记与拓展计划](https://www.lfzxb.top/unity-slate-study-and-extendplan/)

本项目只作为一个最小使用案例，工业级的使用案例请参见：[基于ET框架致敬LOL的Moba游戏，包含完整的客户端与服务端交互，热更新，基于双端行为树的技能系统，更多精彩等你发现！](https://gitee.com/NKG_admin/NKGMobaBasedOnET)

项目使用了两款插件，请自行购买并导入Assets/Plugins/目录中

 - [ParadoxNotion-Slate](https://slate.paradoxnotion.com/)
 - [Odin](https://odininspector.com/)

## 功能列表

- [x] 基于帧同步的技能系统运行时
- [x] 重写Slate创建Group的编辑器界面代码
- [x] 部分Action库
- [x] 技能数据的编辑与导出
- [x] 测试用例

## 使用说明

在Scene场景新建一个游戏物体，并添加图中组件

![image](https://user-images.githubusercontent.com/35335061/129765453-cb24044a-52d4-49eb-9326-b4db06a04b37.png)

主要功能为编辑数据和导出数据

![image](https://user-images.githubusercontent.com/35335061/129765509-077f38ac-d672-42ff-9076-07446ea4f18e.png)

新建一个Skil Group

![image](https://user-images.githubusercontent.com/35335061/129765653-65da6ce7-a542-4f2d-b499-cda41b586b33.png)

新建Action

![image](https://user-images.githubusercontent.com/35335061/129765701-73b0d778-94bc-46df-8dd2-1a61cf907a6f.png)

选中Action即可在Inspector预览和编辑数据

![image](https://user-images.githubusercontent.com/35335061/129765819-c52dae7f-dc20-4717-8eda-7b87041507b1.png)

点击导出数据

![image](https://user-images.githubusercontent.com/35335061/129765861-ce8f6632-4fde-468f-b2f9-9e4fbd56537a.png)

在Scene场景新建一个游戏物体，并为其添加图中组件

![image](https://user-images.githubusercontent.com/35335061/129765931-97d830c0-9ce5-4129-aa5a-63412260eda7.png)

运行游戏，回车键为重新执行技能，空格键为暂停/恢复技能运行

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
