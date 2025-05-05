const npcData = [
    {
      name: "Ireena Kolyana",
      role: "Party Ally",
      location: "Village of Barovia",
      attitude: "Friendly",
    },
    {
      name: "Madam Eva",
      role: "Vistani Seer",
      location: "Tser Pool Encampment",
      attitude: "Neutral",
    },
    {
      name: "Strahd von Zarovich",
      role: "Vampire Lord",
      location: "Castle Ravenloft",
      attitude: "Hostile",
    },
  ];
  
  function loadNPCs() {
    const list = document.getElementById("npc-list");
    list.innerHTML = ""; // clear existing
    npcData.forEach(npc => {
      const div = document.createElement("div");
      div.className = "npc-card";
      div.innerHTML = `
        <h3>${npc.name}</h3>
        <p><strong>Role:</strong> ${npc.role}</p>
        <p><strong>Location:</strong> ${npc.location}</p>
        <p><strong>Attitude:</strong> ${npc.attitude}</p>
      `;
      list.appendChild(div);
    });
  }
  
  function showModule(moduleId) {
    alert(`Module switch: ${moduleId} (you can implement this as needed)`);
  }
  