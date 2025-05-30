#ifndef MINUX_H
#define MINUX_H

#include <iostream>
#include <fstream>
#include <string>
#include <cstring>
#include <cstdlib>
#include <ctime>
#include <curses.h>
#include <termios.h>
#include <unistd.h>
#include <fcntl.h>
#include <sys/ioctl.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <dirent.h>
#include <pwd.h>
#include <grp.h>
#include <vector>
#include <algorithm>
#include "error_console.h"

#define MAX_HISTORY 100
#define VERSION "1.0.0"
#define MAX_PATH 4096
#define MAX_ARGS 32
#define MAX_CMD_LENGTH 1024

// Serial port structure
typedef struct {
    int fd;
    char device[256];
    int baud_rate;
    struct termios old_tio;
    void* port;
    int is_connected;
} SerialPort;

// Command structure
typedef struct {
    const char* name;
    void (*func)(void);
    const char* help;
} Command;

// Global variables
extern ErrorConsole* error_console;
extern Command commands[];
extern char current_path[MAX_PATH];

// Basic command functions
void display_welcome_banner(void);
void cmd_help(void);
void cmd_version(void);
void cmd_time(void);
void cmd_date(void);
void cmd_path(void);
void cmd_ls(const char *path);
void cmd_cd(const char *path);
void cmd_cat(const char *path);
void cmd_history(void);
void cmd_tree(void);
void cmd_tree_interactive(void);

// File and system commands
void show_prompt(void);
void add_to_history(const char* cmd);
void cleanup(void);
void test_camera(void);

// Logging and error functions
void cmd_log(const char *message);

// Audio and media commands
void cmd_play(const char *arg);
void cmd_wav(const char *arg);
void cmd_midi(const char *arg);

// Crypto and wallet commands
void cmd_crypto(const char *arg);
void crypto_show_help(void);
void cmd_wallet(const char *args);

// Todo list commands
void cmd_todo(const char *arg);
void todo_list(void);

// Serial port functions
void serial_monitor(void);

#endif // MINUX_H 