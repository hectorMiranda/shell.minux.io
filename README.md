# Minux Shell - Multi-Language Implementation

A modern, efficient file explorer and shell implementation available in multiple programming languages. This repository contains implementations of the Minux shell in C++, Rust, Python, and .NET, each maintaining the core functionality while leveraging language-specific features and best practices.

## Overview

Minux is a lightweight, feature-rich file explorer and shell that provides:
- Multi-tab file browsing and editing
- Modern ncurses-based UI
- Cryptocurrency wallet integration
- Camera support
- GPIO control capabilities
- Efficient memory management
- Cross-platform compatibility

## Language Implementations

### C++ Implementation
Located in the `cpp/` directory, this is the original implementation featuring:
- ncurses-based UI
- Direct hardware access
- Low-level memory management
- Native performance

### Rust Implementation
Located in the `rust/` directory, offering:
- Memory safety guarantees
- Modern async/await support
- Strong type system
- Zero-cost abstractions

### Python Implementation
Located in the `python/` directory, providing:
- Rapid development capabilities
- Rich ecosystem of libraries
- Cross-platform compatibility
- Easy integration with other Python tools

### .NET Implementation
Located in the `dotnet/` directory, featuring:
- Modern C# language features
- Cross-platform .NET Core support
- Rich UI capabilities
- Enterprise-grade tooling

## Core Features

### File Operations
- Safe path handling
- Directory traversal
- File content preview
- Tab-based file editing
- Memory-mapped file loading

### UI Components
- Drop-down menus
- Color-coded file types
- Status messages
- Mouse support
- Multi-tab interface

### Cryptocurrency Integration
- Secp256k1 key management
- Message signing/verification
- Secure key import/export
- OpenSSL cryptographic operations

### Hardware Support
- Camera integration
- GPIO control
- Hardware-specific optimizations

## Getting Started

### Prerequisites
- C++: GCC with C11 support, ncurses, OpenSSL
- Rust: Latest stable Rust toolchain
- Python: Python 3.8+, required packages in requirements.txt
- .NET: .NET 6.0 SDK or later

### Building

#### C++
```bash
cd cpp
make
```

#### Rust
```bash
cd rust
cargo build --release
```

#### Python
```bash
cd python
pip install -r requirements.txt
```

#### .NET
```bash
cd dotnet
dotnet build
```

### Running

#### C++
```bash
./minux
```

#### Rust
```bash
cargo run --release
```

#### Python
```bash
python main.py
```

#### .NET
```bash
dotnet run
```

## Keyboard Shortcuts
- `Alt+F`: File menu
- `Alt+E`: Edit menu
- `Alt+V`: View menu
- `Alt+H`: Help menu
- `Ctrl+S`: Save file
- `Ctrl+W`: Close tab
- `Tab`: Switch between tabs
- `Enter`: Open file/directory
- `Q`: Quit application

## Technical Details

### Memory Management
- C++: Manual memory management with RAII
- Rust: Ownership and borrowing system
- Python: Automatic garbage collection
- .NET: Managed memory with GC

### UI Framework
- C++: ncurses
- Rust: crossterm
- Python: blessed/curses
- .NET: Terminal.Gui

### Error Handling
- Comprehensive error handling across all implementations
- Language-specific error patterns
- Detailed logging and debugging support

## Contributing

Contributions are welcome! Please read our contributing guidelines before submitting pull requests.

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- Original C++ implementation by [Author]
- Contributors to all language implementations
- Open source community for various libraries and tools used 