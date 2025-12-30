use rppal::gpio::Gpio;
use std::error::Error;
use std::thread;
use std::time::Duration;

const GPIO_LED: u8 = 23;
fn main() {
    println!("Blinking LED on GPIO {}.", GPIO_LED);

    let mut pin = Gpio::new()?.get(GPIO_LED)?.into + output();

    loop {
        pin.toggle();
        thread::sleep(Duration::from_secs(2));
    }
}
