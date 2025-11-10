```mermaid
flowchart LR
  %% Left column (types / combinations)
  subgraph LEFT["Left: Controller types / options"]
    direction TB
    NR["Non-Rigidbody\n(Transform / CharacterController / NavMeshAgent)"]
    SC["Static Collider\n(no Rigidbody)"]
    DR["Dynamic Rigidbody\n(non-kinematic)"]
    KR["Kinematic Rigidbody\n(isKinematic = true)"]
    COMB["Combinations\n(Dynamic↔Dynamic, Dynamic↔Kinematic, Kinematic↔Kinematic)"]
  end

  %% Middle column (movement / scripting approaches)
  subgraph MIDDLE["Middle: Movement approaches / scripting options"]
    direction TB
    TM[Transform.position / direct set]
    CC[CharacterController.Move]
    NM[NavMeshAgent movement]
    RA[Rigidbody.AddForce / set velocity / impulses]
    RM[Rigidbody.MovePosition / MoveRotation]
    STK["Joints and Constraints\n(FixedJoint, Hinge, etc.)"]
    PRT[Parenting / animated transforms]
    RBCOLL[Raycast-based movement / manual collision handling]
  end

  %% Right column (rules of thumb)
  subgraph RIGHT["Right: Rules of thumb"]
    direction TB
    R1[Use FixedUpdate for physics operations]
    R2[Don't set transform on dynamic Rigidbody — use forces/velocity]
    R3[Use MovePosition/MoveRotation for kinematic motion in FixedUpdate]
    R4[CharacterController: tight player control; no physics impulses by default]
    R5[At least one Rigidbody required for reliable OnCollision / OnTrigger callbacks]
    R6[Use Continuous CD for very fast objects (CPU cost)]
    R7[Prefer primitive colliders (box/sphere/capsule); use compound shapes]
    R8[Use physics layers to reduce unnecessary collision checks]
    R9[Use triggers for detection only (no physical response)]
    R10[Avoid moving colliders without a Rigidbody — behavior is unreliable]
    R11[Minimize active dynamics & joint complexity (solver cost)]
    R12[Kinematic / script-driven movement easier to network & predict]
  end

  %% Left -> Middle links (which approaches apply to each left item)
  NR --> TM
  NR --> CC
  NR --> NM
  NR --> PRT
  NR --> RBCOLL

  SC --> TM
  SC --> PRT

  DR --> RA
  DR --> STK
  DR --> PRT
  DR --> RBCOLL

  KR --> RM
  KR --> TM
  KR --> PRT
  KR --> RBCOLL

  COMB --> RA
  COMB --> RM
  COMB --> TM
  COMB --> STK

  %% Middle -> Right links (rules linked to scripting approaches)
  TM --> R10
  TM --> R2
  TM --> R5

  CC --> R4
  CC --> R10
  CC --> R5

  NM --> R12
  NM --> R10
  NM --> R8

  RA --> R1
  RA --> R6
  RA --> R7
  RA --> R5

  RM --> R3
  RM --> R1
  RM --> R5

  STK --> R11
  STK --> R7
  STK --> R1

  PRT --> R10
  PRT --> R5

  RBCOLL --> R8
  RBCOLL --> R9
  RBCOLL --> R1

  %% Visual grouping hints (columns alignment)
  classDef leftCol fill:#f8f9fa,stroke:#333,stroke-width:1px;
  classDef midCol fill:#f0f7ff,stroke:#333,stroke-width:1px;
  classDef rightCol fill:#f7fff0,stroke:#333,stroke-width:1px;

  class NR,SC,DR,KR,COMB leftCol;
  class TM,CC,NM,RA,RM,STK,PRT,RBCOLL midCol;
  class R1,R2,R3,R4,R5,R6,R7,R8,R9,R10,R11,R12 rightCol;
```
