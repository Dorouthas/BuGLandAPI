# Contributing Guide

感谢你对 `BuGLandAPI` 的关注。

## 提交前建议

- 先开 Issue 描述问题或需求，避免重复开发
- 保持改动聚焦，避免一次 PR 混入无关修改
- 优先保持现有风格与命名一致

## 开发流程

1. Fork 本仓库并创建分支（例如：`feature/add-guild-api`）。
2. 在本地开发并执行基础验证：
   - `dotnet restore "./BuGLandAPI.sln"`
   - `dotnet build "./BuGLandAPI.sln" -v minimal`
3. 更新必要文档（如 `README.md`）。
4. 提交 Pull Request，并说明：
   - 变更目的
   - 主要改动点
   - 兼容性影响（如有）

## 代码与设计约定

- 保持 KISS：优先简单直接的实现
- 保持 YAGNI：仅实现当前明确需求
- 保持 DRY：避免重复逻辑
- 保持 SOLID：职责清晰、依赖抽象

## Issue 建议格式

- 环境信息：系统、.NET SDK 版本
- 复现步骤：最小可复现流程
- 期望行为：你希望得到的结果
- 实际行为：当前实际结果或报错信息
