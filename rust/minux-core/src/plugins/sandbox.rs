use crate::MinuxPlugin;

pub struct SandboxPlugin;

impl MinuxPlugin for SandboxPlugin {
    fn name(&self) -> &'static str {
        "Sandbox Plugin"
    }

    fn description(&self) -> &'static str {
        "Sandbox plugin for testing and development."
    }

    fn run(&self) {
        println!("Running Example Plugin...");
    }
}
