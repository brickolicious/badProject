public delegate void Update(object sender);
//this makes sure that the oncomplete event that is defined in the VMs is known throughout the project
//this way when a seperate window is used you can update the other (main) window when you call the event
//delegate will be used to fire oncomplete event in other VM