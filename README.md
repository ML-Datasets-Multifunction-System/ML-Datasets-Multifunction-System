# ML-Datasets-Multifunction-System
编码人员：王艺然 16020510039


分数分配：王艺然100分，林扬豪80分，王瑞轩80分，潘晨洁80分

1.开发所用IDE：VS2017

  开发语言：C#
  
  云服务器平台：阿里云WIndows sever 2012
  
  数据库：mysql（用于存放用户信息）
  
          使用ftp服务器存放用户私有及共享数据集仓库数据
          
  软件运行环境：windows   
  
  运行程序时一定要保证程序存放目录中有MySql.Data.dll ！！！

2.整个工程所有源文件位于ProjectCodes文件夹内

3.可运行程序在此根目录中，名称：MDMS.exe  （运行程序时一定要保证程序存放目录中有MySql.Data.dll ！！！
）

4.所有上交文档位于Files文件夹中

 
5.本软件工程项目制作了一款以数据集生成工具为依托的具有机器学习数据集生成、下载、管理与共享功能的软件。

6.软件功能如下：
  ·数据集生成工具部分：用户可根据自己的图片数据，标定及生成Pascal VOC2007数据集格式的数据集。
  ·数据集生成工具部分：用户需先设定待选类标（目前可设同一图片内最大类标数目为4类）、然后载入待标定数据图片、移动鼠标至标定对象所在位置左上角、按下鼠标、将光标拖动至左下角（中间过程动态生成蓝色方框）、目前单一图片中可标定对象数目为4。
  私有数据集仓库：用户仅可上传数据至自己私有数据仓库、可浏览、下载、删除自己数据库中内容。
  公开数据集仓库：所有用户均可上传数据至公开数据仓库、可浏览、下载、删除公开数据库中内容。
  浏览器部分：内嵌IE内核浏览器，提供常用数据集网址，可方便下载数据集资料、方便浏览查询信息。



