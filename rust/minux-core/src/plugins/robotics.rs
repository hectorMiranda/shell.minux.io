use crate::MinuxPlugin;

pub struct LineFollowerPlugin;

impl MinuxPlugin for LineFollowerPlugin {
    fn name(&self) -> &'static str {
        "Line Follower Plugin"
    }

    fn description(&self) -> &'static str {
        "Simulates a line-following robot behavior."
    }

    fn run(&self) {
        println!("Activating line-following mode: scanning sensor values...");
        println!("Following line using PID control loop... (simulated)");
    }
}
