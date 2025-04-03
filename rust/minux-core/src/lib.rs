pub trait MinuxPlugin {
    fn name(&self) -> &'static str;
    fn description(&self) -> &'static str;
    fn run(&self);
}

pub fn load_plugins() -> Vec<Box<dyn MinuxPlugin>> {
    let mut plugins: Vec<Box<dyn MinuxPlugin>> = Vec::new();

    plugins.push(Box::new(crate::plugins::sandbox::SandboxPlugin));
    plugins.push(Box::new(crate::plugins::robotics::LineFollowerPlugin));

    plugins
}

pub mod plugins {
    pub mod sandbox;
    pub mod robotics;
}
