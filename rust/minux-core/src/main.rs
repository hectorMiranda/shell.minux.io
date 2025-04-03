use minux_core::{load_plugins, MinuxPlugin};

fn main() {
    let plugins = load_plugins();

    println!("Available Plugins:");
    for (i, plugin) in plugins.iter().enumerate() {
        println!("{}: {} - {}", i + 1, plugin.name(), plugin.description());
    }

    println!("\nRunning all plugins:\n");
    for plugin in plugins {
        println!("--- Running {} ---", plugin.name());
        plugin.run();
        println!("-----------------------\n");
    }
}
