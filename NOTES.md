# Implementation Notes

## Goal

Build an ASP.NET Core REST API for inventory and order management with CQRS, persistent storage, pricing rules, stock handling, tests, and submission-ready documentation.

## Agreed Architecture

### Stack

- ASP.NET Core Web API
- SQLite for persistence
- Controllers-based API
- MediatR-style CQRS with separate commands, queries, and handlers
- FluentValidation in the request pipeline
- RFC 7807 ProblemDetails for error responses
- Scalar with OpenAPI 3.1 instead of SwaggerUI

### Solution Structure

A small multi-project solution:

- `Api`
- `Application`
- `Domain`
- `Infrastructure`
- Test project(s)

## Configuration

- Use standard ASP.NET Core configuration with `appsettings` and environment variables.
- Use a feature flag for development seed data so it can be easily disabled.

## API Scope

### Products

Only implement the product endpoints explicitly listed in the task:

- `GET /products`
- `POST /products`

Product rules:

- Required fields: `name`, `description`, `price`, `stock`
- Max length `50` applies only to `name` and `description`
- Numeric fields use normal numeric validation rather than string-length rules

### Customers

Implement full customer CRUD.

Minimal customer model:

- `id`
- `name`
- `pricingRegion`

### Orders

Implement:

- `POST /orders`
- `GET /orders`
- `GET /orders/{id}`

Order request shape:

- `customerId`
- `products`, where each item contains:
  - `productId`
  - `quantity`

## Domain Decisions

### Identifiers

- Use GUIDs for entity identifiers.

### Customer Pricing Region

Store pricing region directly on the customer as an enum:

- `US`
- `Europe`
- `Asia`

No country-to-region mapping is needed.

## Order and Stock Behavior

- Order creation must be transactional.
- If any order line has insufficient stock, reject the entire order.
- Use transactional stock checks only; do not add optimistic concurrency handling for this task.
- Persist pricing snapshots on the order at creation time so historical reads do not change when catalog prices change later.
- `DiscountedQuantity` on an order line means the number of units in that line that received the line discount. For the holiday sale this is one unit; for whole-line discounts it matches the full quantity.

Snapshot data should include the applied pricing inputs and totals needed to explain the final amount.

## Pricing and Discount Rules

### Pricing Order

Apply pricing in this order:

1. Start from the product base price.
2. Apply customer location-based pricing.
3. Evaluate applicable discounts.
4. Apply only the single best discount from the customer's perspective.

### Location-Based Pricing

- `US`: standard pricing
- `Europe`: increase prices by `15%`
- `Asia`: increase prices by `5%`

### Volume Discounts

Volume discounts are evaluated per order line, based on quantity of a single product in that line:

- `5+` units: `10%` discount
- `10+` units: `20%` discount
- `50+` units: `30%` discount

### Seasonal and Promotional Discounts

- Black Friday: `25%` discount on all products
- Holiday sale: `15%` discount on **one unit** of the most expensive product in the order

### Discount Combination Rule

- Discounts cannot be combined.
- The system must choose the highest-value valid discount for the customer.

## Date and Holiday Handling

- Use a holiday library rather than hand-rolled holiday calculations.
- Use an injectable date provider so pricing logic is easy to test and control.
- Polish bank holidays are the reference for holiday-based discounts.

## Validation and Error Handling

### Validation

- Use FluentValidation for all request validation.
- Keep validation separate from controllers and handlers.
- Application commands and queries define the validated request contracts used by the API flow.
- Customer updates will use full-replacement semantics.
- MediatR pipeline validation is preferred over controller-level validation so the application layer enforces the same rules regardless of the caller.
- This keeps handlers focused on business logic, avoids repeating validation in each controller action, and lets future non-HTTP entry points reuse the same command/query validation behavior.

### Error Responses

Use ProblemDetails consistently for:

- validation failures
- not found responses
- business rule violations
- unexpected server errors

## Testing Strategy

Implement:

- Unit tests for pricing, discount, and stock rules
- Focused integration tests for main HTTP flows:
  - customer CRUD
  - product create/list
  - order create/read

## Documentation Scope

This file captures:

- assumptions
- simplifications
- implementation decisions
- trade-offs agreed during planning

## Explicit Trade-Offs

- Full customer CRUD is included because orders depend on a real `customerId` and customer pricing region.
- Product API is intentionally limited to the explicitly listed endpoints, even though the original objective mentions CRUD more broadly.
- Order editing and cancellation are out of scope.
- List endpoints remain unpaginated because the task focuses on business rules rather than query features.
- Validation is executed through the MediatR pipeline instead of ASP.NET controller model validation to keep CQRS request rules centralized in the application layer, at the cost of a bit more infrastructure setup.
