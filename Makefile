# Variables
COMPOSE_PROJECT_NAME=vrom
DOCKER_IMAGE=vrom
DOCKERFILE_PATH=src/FOV.Presentation/Dockerfile
DOCKER_COMPOSE_FILE=docker-compose.yml

# Targets
.PHONY: all build run remove reset update help

# Default target
all: remove build run

# Display help
help:
	@echo "Available targets:"
	@echo "  all     - Remove, build, and run containers"
	@echo "  remove  - Stop and remove containers and volumes"
	@echo "  build   - Build the Docker image"
	@echo "  run     - Start containers using docker-compose"
	@echo "  reset   - Full cleanup and rebuild"
	@echo "  update  - Rebuild and restart specific services"
	@echo "  help    - Display this help message"

# Remove containers and volumes
remove:
	@echo "Stopping and removing containers and volumes..."
	@docker-compose --project-name down -v

# Build the Docker image
build:
	@echo "Building Docker image..."
	@docker build -t $(DOCKER_IMAGE) -f $(DOCKERFILE_PATH) .

# Run containers using docker-compose
run:
	@echo "Starting containers..."
	@docker-compose --project-name $(COMPOSE_PROJECT_NAME) up -d

# Update specific service(s)
update:
	@echo "Rebuilding and restarting services..."
	@docker-compose --project-name $(COMPOSE_PROJECT_NAME) up -d --build

# Reset: full cleanup and rebuild
reset: remove build update
