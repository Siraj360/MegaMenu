
# Building a Mega Menu UI in Blazor Server (.NET 9) 

In this project, we build a dynamic, data-driven Mega Menu in a Blazor Server app using .NET 9, Bootstrap 5, and Font Awesome 6. This README walks through the core concepts, code snippets, and setup steps.


## The end result

![Mega Menu Screenshot](https://github.com/Siraj360/MegaMenu/blob/main/wwwroot/img/Screen.gif)



### A bolg on theis project

[Building a Mega Menu and Menu Builder UI in Blazor Server (.NET 9)](https://medium.com/@sirajg360/building-a-mega-menu-and-menu-builder-ui-in-blazor-server-net-9-5dc39e718cdc)



## 🎯 Goals

- ✅ Create a dynamic Mega Menu using a JSON data structure.
- ✅ Style it with Bootstrap and Font Awesome.
- ✅ Define menu structure with C# POCO models and load JSON in Blazor.
- 🚧 Prepare for a future visual Menu Builder UI with real-time editing.

## 🔧 Technologies Used

- **Blazor Server** (.NET 9 Preview)
- **Bootstrap 5**
- **Font Awesome 6**
- **C# POCO classes**
- **JSON** data format for menus


## 📁 Step 1: Define POCO Classes for Menu Structure

```csharp
public class MegaMenuTopLink
{
    public Guid TopLinkID { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Icon { get; set; }
    public string RightOffset { get; set; } // Optional
    public List<MegaMenuGroup> Groups { get; set; } = new();
}

public class MegaMenuGroup
{
    public Guid GroupID { get; set; } = Guid.NewGuid();
    public List<MegaMenuItem> Items { get; set; } = new();
}

public class MegaMenuItem
{
    public Guid ItemID { get; set; } = Guid.NewGuid();
    public string Type { get; set; } // "link", "title", "separator", "image"
    public string Text { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
    public string Class { get; set; }
    public string Src { get; set; } // For images
    public string Alt { get; set; } // Alt text for images
}
```


## 📄 Step 2: Sample JSON Menu Data

```json
[
  {
    "topLinkID": "guid-here",
    "name": "Dashboard",
    "icon": "fa fa-gauge",
    "groups": [
      {
        "groupID": "guid-here",
        "items": [
          {
            "itemID": "guid-here",
            "type": "title",
            "text": "Reports",
            "icon": "fa fa-chart-bar",
            "class": "text-primary"
          },
          {
            "itemID": "guid-here",
            "type": "link",
            "text": "Sales",
            "url": "/sales",
            "icon": "fa fa-dollar-sign"
          }
        ]
      }
    ]
  }
]
```


## 🔁 Step 3: Loading JSON in Blazor Component (`NavMegaMenu360.razor`)

```csharp
@inject HttpClient Http
@inject NavigationManager NavManager

@code {
    private List<MegaMenuTopLink> MenuLinks = new();
    private string ErrorMessage;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var url = new Uri(new Uri(NavManager.BaseUri), "menu-test.json").ToString();
            MenuLinks = await Http.GetFromJsonAsync<List<MegaMenuTopLink>>(url);
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Error loading menu.json: {ex.Message}";
        }
    }
}
```


## 🧱 Step 4: Mega Menu UI Component Markup

```razor
<ul class="mega-menu-nav">
    @foreach (var topLink in MenuLinks)
    {
        <li class="top-link-item">
            <a href="#"><i class="@topLink.Icon"></i> @topLink.Name</a>
            <div class="dropdown mega-dropdown" style="right:@topLink.RightOffset">
                <div class="dropdown-content m-3">
                    @foreach (var group in topLink.Groups)
                    {
                        <div class="dropdown-col">
                            @foreach (var item in group.Items)
                            {
                                @switch (item.Type?.ToLower())
                                {
                                    case "title":
                                        <h5 class="dropdown-title @item.Class">
                                            <i class="@item.Icon"></i> @item.Text
                                        </h5>
                                        break;
                                    case "link":
                                        <a href="@item.Url" class="dropdown-link @item.Class">
                                            <i class="@item.Icon"></i> @item.Text
                                        </a>
                                        break;
                                    case "separator":
                                        <hr class="dropdown-separator" />
                                        break;
                                    case "image":
                                        <img src="@item.Src" alt="@item.Alt" />
                                        break;
                                }
                            }
                        </div>
                    }
                </div>
            </div>
        </li>
    }
</ul>
```


## 🎨 Embedded CSS Styling

```css
.mega-dropdown {
    position: absolute;
    display: none;
    background-color: #e6f9ff;
    z-index: 9999;
    border-radius: 4px;
}

.top-link-item:hover > .mega-dropdown {
    display: flex;
    padding: 1rem;
}

.dropdown-content {
    display: flex;
    gap: 2rem;
}

.dropdown-title {
    font-weight: bold;
    margin-bottom: 0.5rem;
}

.dropdown-separator {
    border-top: 1px solid #007399;
}
```

---

## 💡 Summary

- Created a reusable, data-driven Mega Menu in Blazor using POCO + JSON
- Dynamic loading of menu items with icons and groups
- CSS hover dropdown for a smooth UI experience
- Font Awesome integrated for iconography
- Base ready for future visual menu builder enhancements

---

## ⏭️ Next Steps (Part II)

- Develop a visual Mega Menu Builder UI in Blazor
- Add functionality to add/edit/delete menu links, groups, and items
- Bind UI controls directly to JSON for live editing and preview
- Implement a "Save to JSON" feature for persistence

Stay tuned!

---

## License

This project is licensed under the MIT License.
