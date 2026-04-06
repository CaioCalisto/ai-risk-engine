# Context

Project: AiRiskEngine
Purpose: Evaluate risk of user transactions to prevent fraud.

## Entities

- User
    - userId: string
    - country: string (ISO code, e.g., "PT")
    - age: integer

- Transaction
    - transactionAmount: decimal
    - timestamp: datetime (optional)

- RiskScore
    - score: integer (0-100)
    - decision: APPROVE / REVIEW / BLOCK
    - reason: short explanation

## Business rules

- High transaction amounts are higher risk
- Certain countries may have higher risk
- Age can influence risk
- System must always provide a clear reason

This file serves as a **reference for AI**, describing domain and entities.
