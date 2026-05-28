# POE2
# 🛡️ Cybersecurity Awareness Chatbot

[![Version](https://img.shields.io/badge/version-1.0.0-brightgreen.svg)](https://github.com/yourusername/CyberSecurityChatbot)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/)
[![WPF](https://img.shields.io/badge/UI-WPF-purple.svg)](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/)
[![License](https://img.shields.io/badge/license-MIT-yellow.svg)](LICENSE)
[![C#](https://img.shields.io/badge/C%23-12.0-green.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)

## 📋 Overview

The **Cybersecurity Awareness Chatbot** is a sophisticated WPF desktop application developed in C# using .NET 8.0. It is designed to educate users about cybersecurity threats through an engaging, interactive chat system. The chatbot uses **modular object-oriented programming (OOP)** principles, where each class has a **single responsibility** to ensure clean architecture, maintainability, and scalability.

### 🎯 Purpose

In today's digital age, cybersecurity threats are increasingly common. This chatbot aims to:
- **Educate users** about common cybersecurity threats and best practices
- **Provide actionable tips** for staying safe online
- **Create awareness** about passwords, scams, privacy, malware, and 2FA
- **Offer personalized guidance** based on user interests and concerns
- **Detect user emotions** and respond with empathy and support

---

## ✨ Key Features

### 🤖 Core Chatbot Features
| Feature | Description |
|---------|-------------|
| **Keyword Recognition** | Detects cybersecurity topics like passwords, scams, privacy, malware, and 2FA |
| **Random Responses** | Provides varied tips using arrays of predefined responses for dynamic conversations |
| **Sentiment Analysis** | Recognizes user emotions (worried, frustrated, curious, positive) and responds empathetically |
| **Memory System** | Remembers user name and interests throughout the conversation session |
| **Follow-up Support** | Handles "another tip", "tell me more", and follow-up questions naturally |

### 🎨 User Interface Features
- **Modern Dark Theme** - Eye-friendly #0F172A background with neon green (#00FF96) accents
- **Message Bubbles** - Different colors for user (blue) and bot (dark) messages with rounded corners
- **Timestamps** - Each message shows delivery time (hh:mm tt format)
- **Responsive Layout** - Scales properly with window resizing
- **Custom Buttons** - Hello, Voice, Images, and Clear Chat functionality
- **Placeholder Text** - "Type your message here..." guide in input box

### 🔊 Additional Features
- **Voice Greeting** - Audio feedback on button click using System.Media
- **Typing Simulation** - Natural conversation flow with slight delays
- **Auto-scroll** - Automatically scrolls to newest messages
- **Enter Key Support** - Send messages with keyboard for convenience
- **Chat History** - Maintains conversation context
- **Help System** - Complete command guide available anytime

---

## 🚀 Quick Start

### Prerequisites

| Requirement | Version |
|-------------|---------|
| **Visual Studio** | 2022 or later |
| **.NET Framework** | 8.0 or later |
| **Operating System** | Windows 10/11 |
| **RAM** | 4GB minimum |
| **Disk Space** | 100MB free |

### Installation (3 Simple Steps)

#### Step 1: Create New Project
```bash
Open Visual Studio → File → New → Project → WPF Application → Name: "SmartChat"
