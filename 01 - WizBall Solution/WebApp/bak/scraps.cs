<asp:CheckBox Text="<%# DataBinder.Eval(Container.DataItem, "Name") %>" value="<%# DataBinder.Eval(Container.DataItem, "ID") %>" ID="Comp<%# DataBinder.Eval(Container.DataItem, "ID") %>" runat="server" />
<input type="checkbox" id="Comp<%# DataBinder.Eval(Container.DataItem, "ID") %>"  name="<%# DataBinder.Eval(Container.DataItem, "ID") %>" value="<%# DataBinder.Eval(Container.DataItem, "Name") %>" />



                                    <asp:CheckBox Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' value='<%# DataBinder.Eval(Container.DataItem, "ID") %>' ID='CheckBox1' runat="server"/>

                                    
                                                <asp:CheckBox value='<%# DataBinder.Eval(Container.DataItem, "ID") %>' ClientIDMode="Static" ID='CheckBox1' runat="server" />

                                                <input type="checkbox" name="var_id[]" id="<%# DataBinder.Eval(Container.DataItem, "ID") %>" value="<%# DataBinder.Eval(Container.DataItem, "ID") %>">




                                                // 2.5x Row--------------------------------------------------------------------------------------------------

                    // Row
                    HtmlGenericControl recRow = new HtmlGenericControl("div");
                    recRow.Attributes["class"] = "row p-0 m-0";
                    // Col
                    HtmlGenericControl recCol = new HtmlGenericControl("div");
                    recCol.Attributes["style"] = "font-size:15px; padding: 2px 0;";
                    recCol.Attributes["class"] = "col-sm-12 pl-4 text-white font-weight-bold rounded-bottom";

                    Label lblRec = new Label();
                    lblRec.Text = "2.5x";
                    if (true) //verificar 2.5x
                    {
                        recCol.Attributes["class"] += "bg-success";
                    }
                    else
                    {
                        recCol.Attributes["class"] += "bg-warning";
                    }
                    lblRec.Attributes["style"] = "";