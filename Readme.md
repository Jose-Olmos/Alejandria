# Alejandria WebAPI

## Run
* ### Docker
	* Put "Docker" value on the "Environment" key inside the appsettings.json file on the Alejandria.WebAPI project.
	* Run "docker-compose up" at the root of the project.

* ### Localhost
	* Put "Development" value on the "Environment" key inside the appsettings.json file on the Alejandria.WebAPI project.
	* Run the projects using "Alejandria.(project)" profile.

## Notes
When running docker, on the first run, you might have to reboot the container. 
That is because the Alejandria database is not created yet when the WebAPI attempts to run the first migration,
the connection fails and when the database is finally created, it is left without tables, causing the malfunction of the app.
The second time the database is already created and the migration is performed correctly.